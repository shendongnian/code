    bool dotNetBoolean;
    var booleansFromOtherSystem = new[] { "hello", "TRUE", "FalSE", "FoO", "bAr" };
    foreach (var value in booleansFromOtherSystem)
    {
        if (!SpecificBooleanConverter.TryParse(value, out dotNetBoolean))
        {
            Console.WriteLine("Could not parse \"" + booleansFromOtherSystem + "\".");
        }
        if (dotNetBoolean == true)
        {
            Console.WriteLine("Yes, we can.");
        }
        else
        {
            Console.WriteLine("No, you don't.");
        }
    }
