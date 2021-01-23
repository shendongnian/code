    private byte[] zipText(string text)
    {
        if (text == null)
            return null;
    
        using(Stream memOutput = new MemoryStream())
        {
            using (GZipOutputStream zipOut = new GZipOutputStream(memOutput))
            {
                using (StreamWriter writer = new StreamWriter(zipOut))
                {
                    writer.Write(text);
    
                    writer.Flush();
                    zipOut.Finish();
    
                    byte[] bytes = new byte[memOutput.Length];
                    memOutput.Seek(0, SeekOrigin.Begin);
                    memOutput.Read(bytes, 0, bytes.Length);
    
                    return bytes;
                }
            }
        }
    }
    
    private string unzipText(byte[] bytes)
    {
        if (bytes == null)
            return null;
    
        using(Stream memInput = new MemoryStream(bytes))
        using(GZipInputStream zipInput = new GZipInputStream(memInput))
        using(StreamReader reader = new StreamReader(zipInput))
        {
            string text = reader.ReadToEnd();
    
            return text;
        }
    }
