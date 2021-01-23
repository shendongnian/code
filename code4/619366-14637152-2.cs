    {
        StreamReader sr = new StreamReader(path);
        try
        {
            while (sr.Peek() >= 0) 
                Console.WriteLine(sr.ReadLine());
        }
        finally
        {
            if(sr != null)
                sr.Dispose();
        }
    }
