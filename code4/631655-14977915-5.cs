    string jsonString = "someString";
    try
    {
        var tmpObj = JsonValue.Parse(jsonString);
    }
    catch (FormatException fex)
    {
        //Invalid json format
        Console.WriteLine(fex);
    }
    catch (Exception ex) //some other exception
    {
        Console.WriteLine(ex.ToString());
    }
