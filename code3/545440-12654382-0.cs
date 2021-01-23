    private static string GetString()
    {
        FileStream fs = new FileStream("path", FileMode.Open);
        try
        {
            StreamReader sr = new StreamReader(fs);
            try
            {
                return sr.ReadToEnd();
            }
            finally
            {
                if (sr != null)
                    ((IDisposable)sr).Dispose();
            }
        }
        finally
        {
            if (fs != null)
                ((IDisposable)fs).Dispose();
        }
    }
