    using (FileStream fs = new FileStream(outFileName, FileMode.Create))
    {
        using (StreamWriter writer = new StreamWriter(fs, Encoding.Unicode))
        {
            writer.WriteLine(someString)
        }
    }
    using (StreamReader rdr = new StreamReader(File.OpenRead(CsvFilePath)))
    {
        string header = rdr.ReadLine();
    }
