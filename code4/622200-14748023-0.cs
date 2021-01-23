    string[] lines = System.IO.File.ReadAllLines(ofdFile.FileName);
    foreach (var line in lines)
    {
        string[] parts = line.Split('*');
        AddtoSQL(parts[0], parts[1]);
    }
