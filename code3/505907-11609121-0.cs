        byte[] result;
        using (MemoryStream ms = new MemoryStream())
        using (StreamWriter sw = new StreamWriter(ms))
        {
            MyFileWriter.WriteToFile(someData, sw);
            result = ms.ToArray();
        }
        // use the result byte[]
