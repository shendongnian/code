    try
    {
        using (Stream output = request.GetRequestStream())
            output.Write(buffer, 0, buffer.Length);
        var response = request.GetResponse() as HttpWebResponse;
        //TODO: check response.StatusCode, etc.
    }
    catch(WebException wE)
    {
        Console.WriteLine(wE.Message);
    }
