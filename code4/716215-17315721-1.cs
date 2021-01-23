       public async Task ParseReport(byte[] bytesRead)
        {
            Stream stream = new MemoryStream(bytesRead);
            using (StreamReader reader = new StreamReader(stream))
                {
                string line = null;
                while (null != (line = reader.ReadLine())) 
                {
                  string[] values = line.Split(';');
                }
                }
            stream.Close();
        }
