    var dbtables = System.IO.Directory.GetFiles(db);
    foreach (string table in dbtables)
    {
        string temp = table + ".tmp";
        using (StreamWriter target = new StreamWriter(temp))
            foreach (string line in File.ReadLines(table))
                target.WriteLine(line.Trim());
        File.Delete(table);
        File.Move(temp, table);
    }
