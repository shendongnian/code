    string  theFilePathName = “filepathname.csv”;
    try{
        FileStream FS;
        StreamWriter SW;
        FS = new FileStream(theFilePathName, FileMode.Create);
        SW = new StreamWriter(FS);
        foreach (var generator in GeneratorNames)
        {
            SW.WriteLine("   GeneratorName is: {0}", generator.name);
            sb_report.AppendLine(string.Join(delimiter, filename,
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
