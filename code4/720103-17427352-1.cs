    try{
        FileStream FS;
        StreamWriter SW;
        FS = new FileStream(filename, FileMode.Create);
        SW = new StreamWriter(FS);
        foreach (var generator in GeneratorNames)
        {
            SW.WriteLine(string.Join(delimiter, filename,
            generator.name));
        }
        SW.Close();
        SW.Dispose();
        FS.Close();
        FS.Dispose();
    }
    catch (Exception e){
        Console.Writeline(e.ToString());
    }
