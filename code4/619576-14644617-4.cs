    var tabPath = path;
    var csvPath = Path.Combine(
                    Path.GetDirectoryName(path), 
                    String.Format("{0}.{1}", Path.GetFileNameWithoutExtension(path), "csv"));
    using (var sr = new StreamReader(tabPath))
    using (var sw = new StreamWriter(csvPath, false))
    {
        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine().Split('\t').Select(field => field.EscapeCsvField(',', '"')).ToArray();
            var csv = String.Join(",", line);
            sw.WriteLine(csv);
        }
    }
    File.Delete(tabPath);
