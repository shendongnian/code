    StreamWriter sw = null;
    StreamReader sr = null;
    try
    {
        using (var ms = new MemoryStream())
        {
            sw = new StreamWriter(ms);
            sr = new StreamReader(ms);
            sw.WriteLine("data");
            sw.WriteLine("data 2");
            ms.Position = 0;
            Console.WriteLine(sr.ReadToEnd());                        
        }
    }
    finally
    {
        if (sw != null) sw.Dispose();
        if (sr != null) sr.Dispose();
    }
