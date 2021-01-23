    Console.Write("Enter temp in fahrenheit: ");
    double fahrenheit;
    string userInput = Console.ReadLine();
    if(double.TryParse(userInput, out fahrenheit))
    {
        double celsius = (fahrenheit - 32.0) * (5.0 / 9.0);
        Console.WriteLine("Celsius is: " + celsius);
    }
    else
    {
        Console.WriteLine("Non a valid double value");
    }
    Console.ReadLine();
