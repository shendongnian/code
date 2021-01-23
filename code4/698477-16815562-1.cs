    using System.Globalization;
    
    string[] format = { "yyyy/MM/dd", "MM/dd/yyyy" };
    DateTime valueDate;
    var value = "2013/01/21";
    if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out valueDate))
    {
        Console.WriteLine("Success!");
    }
    else
    {
        Console.WriteLine("Failure!");
    }
