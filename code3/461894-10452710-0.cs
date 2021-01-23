    using (var reader = new StreamReader("inputFileName"))
    {
        using (var writer = new StreamWriter("outputFileName"))
        {
            char[] buff = new char[4];
            int readCount = 0;
            while((readCount = reader.Read(buff, 0, 4)) > 0)
            {
                //manipulations with buff
        
                writer.Write(buff);
            }
        }
    }
