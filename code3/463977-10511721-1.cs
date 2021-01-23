    static void InsertHeader(string filename, string header)
    {
        var tempfile = Path.GetTempFileName();
        using (var writer = new StreamWriter(tempfile))
        using (var reader = new StreamReader(filename))
        {
            writer.WriteLine(header);
            while (!reader.EndOfStream)
                writer.WriteLine(reader.ReadLine());
        }
        File.Copy(tempfile, filename, true);
        File.Delete(tempfile);
    }
