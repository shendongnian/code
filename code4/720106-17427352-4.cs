    try{
        FileStream FS;
        StreamWriter SW;
        using (FS = new FileStream("HardCodedFileName.csv", FileMode.Append))
        {
            using (SW = new StreamWriter(FS))
            {
                foreach (var generator in GeneratorNames)
                {
                    SW.WriteLine(string.Join(delimiter, filename,
                    generator.name));
                }
            }
        }
    }
    catch (Exception e){
        Console.Writeline(e.ToString());
    }
