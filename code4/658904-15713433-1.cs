    ...
    string tableName = "DataImport";
    List<string> rows = new List<string>();
    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        using (StreamReader reader = new StreamReader(fs, encoding))
        {
            string record = reader.ReadLine();
            while (record != null)
            {
                rows.Add(record);
                record = reader.ReadLine();
            }
        }
    }
    ...
