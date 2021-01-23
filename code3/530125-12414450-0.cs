    using (var Sr = new StreamReader("\\SomeCoolFile.CSV"))
    {
        var text = Sr.ReadToEnd();
        Sr.Close();
        text = text.Replace("\n", string.Empty);
        var lines = text.Split('\r');
        var info = lines.Select(line => line.Split(',')).ToList();
        ......
    }
