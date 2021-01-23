    try{
        FileStream FS;
        StreamWriter SW;
        using (FS = new FileStream(filename, FileMode.Create))
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
