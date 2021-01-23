    FileStream fs = new FileStream("path", FileMode.Open)
    
    try
    {
        StreamReader sr = new StreamReader(fs)
        try
        {
            toReturn = sr.ReadToEnd();
            return toReturn;
        }
        finally
        {
           if(sr != null)
               sr.Dispose();
        }
    }
    finally
    {
        if(fs != null)
            fs.Dispose();
    }
