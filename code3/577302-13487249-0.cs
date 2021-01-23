    public DataTable GetDataSourceFromFile(string fileName)
    {
        DataTable dt = new DataTable("CreditCards");
        string[] columns = null;
        var lines = File.ReadAllLines(fileName);
        // assuming the first row contains the columns information
        if (lines.Count() > 0)
        {
            columns = lines[0].Split(new char[] { ',' });
            foreach (var column in columns)
                dt.Columns.Add(column);
        }
        // reading rest of the data
        for (int i = 1; i < lines.Count(); i++)
        {
            DataRow dr = dt.NewRow();
            string[] values = lines[i].Split(new char[] { ',' });
            for (int j = 0; j < values.Count() && j < columns.Count(); j++)
                dr[j] = values[j];
            dt.Rows.Add(dr);
        }
        return dt;
    }
