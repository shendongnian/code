    string jsonString = "someString";
    try
    {
        var obj = JToken.Parse(jsonString);
    }
    catch (JsonReaderException jex)
    {
        //Exception in parsing json
        Console.WriteLine(jex.Message);
    }
    catch (Exception ex) //some other exception
    {
        Console.WriteLine(ex.ToString());
    }
