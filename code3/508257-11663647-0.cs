    string name;
    while ((name = reader.ReadLine()) != null)
    {
        string payText = reader.ReadLine();
        if (payText == null)
        {
            // Or whatever exception you want to throw...
            throw new InvalidDataException("Odd number of lines in file");
        }
        Employee employee = ParseTextValues(name, payText);
        Console.WriteLine("{0}: {1}", employee.Name, employee.Hours * employee.Wage);
    }
