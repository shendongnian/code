    using (Stream ms = new MemoryStream())  
    {
        UnZipFile(response.GetResponseStream(), ms);
        
        string content;
        
        ms.Position = 0;
        using(StreamReader s = new StreamReader(ms))
        {
            content = s.ReadToEnd();
        } 
    }
    public static void UnZipFile(Stream inputStream, Stream outputWriter)
    {      
        using (var zipStream = new ZipInputStream(inputStream))
        {
            ZipEntry currentEntry;
            if ((currentEntry = zipStream.GetNextEntry()) != null)
            {
                int size = 2048;
                byte[] data = new byte[size]; 
                while (true)
                {
                    size = zipStream.Read(data, 0, size);
                    if (size > 0)
                    {
                        outputWriter.Write(data);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
