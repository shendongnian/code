    DataTable dt = new DataTable();
    while (reader.Peek() >= 0)
    {
        string line = reader.ReadLine();
        string[] fields = line.Split('\t');
        if (dt.Columns.Count == 0)
        {
            foreach (string field in fields)
            {
                // will add default names like "Column1", "Column2", and so on
                dt.Columns.Add(); 
            }
        }
        dt.Rows.Add(fields);
    }
