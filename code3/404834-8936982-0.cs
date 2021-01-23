    try 
    {
        var response = request.GetResponse(); 
    }
    catch (WebException webEx) 
    {
        Console.WriteLine("Error: {0}", ((HttpWebResponse)webEx.Response).StatusDescription);
    }
    
