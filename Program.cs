bool running = true;
List<string> historial = new List<string>();

while (running)
{
    try
    { 
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("================================");
        Console.WriteLine("          CALCULADORA           ");
        Console.WriteLine("================================");
        Console.ResetColor();

        Console.WriteLine("1. Suma");
        Console.WriteLine("2. Resta");
        Console.WriteLine("3. Multiplicacion");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Evaluar estudiante (Aprobo o no?)");
        Console.WriteLine("6. Ver el historial de operaciones");
        Console.WriteLine("7. Salir");

        Console.Write("Digite el numero de la opcion que deseas: ");

        int typedOption = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        switch (typedOption)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                {
                    historial.Add($"Operacion: {typedOption}");
                    break;
                }
            case 5:
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" EVALUACION ACADEMICA ");
                    Console.ResetColor();

                    decimal suma = 0;
                    int totalNotas = 4;
                    for (int i = 1; i <= totalNotas; i++)
                    {
                        suma += LeerNota(i);
                    }

                    decimal promedio = suma / totalNotas;
                    string literal = "";
                    string estado = "";

                    Console.WriteLine($"\nPromedio calculado: {promedio:F2}");

                    switch (promedio)
                    {
                        case decimal n when (n >= 90):
                            literal = "A";
                            estado = "Aprobado";
                            MostrarExito("Felicitaciones!, aprobo con una calificacion de A.");
                            break;
                        case decimal n when (n >= 80):
                            literal = "B";
                            estado = "Aprobado";
                            MostrarExito("Muy bien!, aprobo con una calificacion de B.");
                            break;
                        case decimal n when (n >= 70):
                            literal = "C";
                            estado = "Aprobado";
                            MostrarExito("Bien!, aprobo con una calificacion de C.");
                            break;
                        default:
                            literal = "F";
                            estado = "No Aprobado";
                            MostrarError("Lo siento, no aprobo.");
                            break;
                    }
                    string registroNota = $"[{DateTime.Now:HH:mm}] Evaluacion: promedio {promedio:F2} | Literal {literal} | Estado: {estado}";
                    historial.Add(registroNota);

                    PausarYLimpiar();
                    continue;
                }
            case 6:
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("HISTORIAL DE OPERACIONES");
                    Console.ResetColor();

                    if (historial.Count == 0)
                    {
                        Console.WriteLine("Todavia no hay operaciones registradas en el historial.");
                    }
                    else
                    {
                        for (int i = 0; i < historial.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {historial[i]}");
                        }
                        Console.WriteLine("\nDesea borrar el historial? (s/n): ");
                        string respuesta = Console.ReadLine().Trim().ToLower();
                        if (respuesta == "s")
                        {
                            historial.Clear();
                            MostrarExito("Historial borrado.");
                        }
                    }
                    PausarYLimpiar();
                    continue;
                }
            case 7:
                {
                    Console.Write(" Seguro de que quiere salir? (s/n): ");
                    string confirmar = Console.ReadLine().Trim().ToLower();

                    if (confirmar == "s")
                    {
                        running = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nChau, Hasta prontito!");
                        Console.ResetColor();
                    }
                    else
                    {
                        PausarYLimpiar();
                    }
                    continue;
                }
            default:
                {
                    MostrarError("Opcion invalida. Porfavor, seleccione un numero del 1 al 7. ");
                    PausarYLimpiar();
                    continue;
                }

        }
        
        List <decimal> typedNumbers = new List<decimal>();
        bool terminar = false;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("INGRESO DE NUMEROS");
        Console.ResetColor();

        while (!terminar)
        {
            if (typedNumbers.Count > 0)
            {
                Console.Write("Numeros acumulados: "+ string.Join (",", typedNumbers));
            }
            Console.Write($"Escriba el numero {typedNumbers.Count + 1} ('listo' para calcular,'borrar' para quitar el ultimo):");
            string entrada = Console.ReadLine().Trim().ToLower();

            switch (entrada)
            {
              case "listo" when typedNumbers.Count >= 2:
                    {
                        terminar = true;
                        break;
                    }
                case "listo":
                    {
                        MostrarError("Debe ingresar al menos 2 numeros antes de calcular.");
                        break;
                    }
                case "borrar" when typedNumbers.Count > 0:
                  {
                        typedNumbers.RemoveAt(typedNumbers.Count - 1);
                        Console.WriteLine("Se elimino el ultimo numero.");
                        break;
                    }
                case "borrar":
                    {
                        MostrarError("No hay numeros para borrar.");
                        break;
                    }
                case string s when decimal.TryParse(s,out decimal valor):
                    {
                        typedNumbers.Add(valor);
                        break;
                    }
                default:
                    {
                        MostrarError("Error: ingrese un numero valido, 'listo' o 'borrar'.");
                        break;
                    }
    }
}

            decimal result = 0;
            string nombreOperacion = "";
            string simbolo = "";

            switch (typedOption)
            {

                case 1:
                    {
                        result = 0;
                        for (int i = 0; i< typedNumbers.Count; i++)
                        {
                            result += typedNumbers[i];
                        }
                        nombreOperacion = "Suma";
                        simbolo = "+";
                        break;
                    }
                case 2:
                    {
                        result = typedNumbers[0];
                        for (int i = 1; i <typedNumbers.Count; i++)
                        {
                            result -= typedNumbers[i];
                        }
                        nombreOperacion = "Resta";
                        simbolo = "-";
                        break;
                    }
                case 3:
                    {
                        result = 1;
                        for (int i = 0; i <typedNumbers.Count; i++)
                        {
                            result *= typedNumbers[i];
                        }
                        nombreOperacion = "Multiplicacion";
                        simbolo = "*";
                        break;
                    }
                case 4:
                    {
                        result = typedNumbers[0];
                        for (int i = 1; i <typedNumbers.Count; i++)
                        {
                            if (typedNumbers[i]==0)
                            {
                                throw new DivideByZeroException();
                            }
                            result /= typedNumbers[i];
                        }
                        nombreOperacion = "Division";
                        simbolo = "/";
                        break;
                    }

            }
            string expresion = string.Join($" {simbolo} ", typedNumbers);

            Console.WriteLine();
            Console.WriteLine($"Operacion seleccionada: {nombreOperacion}");
            Console.WriteLine($"Expresion: {expresion}");
            MostrarExito($"El resultado final es: {result}");

            string registroOperacion = $"[{DateTime.Now:HH:mm}] {nombreOperacion}: {expresion} = {result}";
            historial.Add(registroOperacion);

            PausarYLimpiar();
        }
catch (FormatException)
    {
        MostrarError("Error: Debe ingresar un numero valido.");
        PausarYLimpiar();
    }
    catch (DivideByZeroException)
    {
        MostrarError("Error: No se puede dividir entre cero.");
        PausarYLimpiar();
    }
    catch (OverflowException)
    {
        MostrarError("Error: El numero es demasiado grande.");
        PausarYLimpiar();
    }
    catch (Exception ex)
    {
        MostrarError($"Error inesperado: {ex.Message}");
        PausarYLimpiar();
    }
}
static void MostrarError(string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(mensaje);
    Console.ResetColor();
}

static void MostrarExito(string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(mensaje);
    Console.ResetColor();
}

static void PausarYLimpiar()
{
    Console.WriteLine();
    Console.WriteLine("Presione una tecla para regresar al menu...");
    Console.ReadKey();
    Console.Clear();
}

static decimal LeerNota(int numero)
{
    decimal nota = 0;
    bool valida = false;

    while (!valida)
    {
        Console.Write($"Digite la nota {numero} (0 a 100): ");
        bool esNumero = decimal.TryParse(Console.ReadLine(), out nota);
        valida = esNumero && nota >= 0 && nota <= 100;

        if (!valida)
        {
            MostrarError("Nota invalida. Debe ingresar una calificacion entre 0 y 100.");
        }
    }

    return nota;
}
