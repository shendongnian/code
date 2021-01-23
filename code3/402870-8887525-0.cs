    using (var stream = response.GetStream())
    using (var reader = new StreamReader(stream))
    {
        string data = reader.ReadToEnd();
        int value;
        if (int.TryParse(data, out value))
        {
            // the parsing was successful => you could do something with
            // the integer value you have just read from the body of the response
        }
    }
