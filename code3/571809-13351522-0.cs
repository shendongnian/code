    int count;
    Dictionary<string, int> d = new Dictionary<string, int>();
    foreach (DataRow dr in dataSet1.Tables["Table1"].Rows)
    {
        d.Add((string)dr[0], count);
        count++;
    }
    foreach (string textfileitem in TheTextFile)
    {
        string item = //specific data from textfileitem
        int value;
        if (d.TryGetValue(item, out value)
        {
            DataRow[] dr = dataSet1.Tables["Table1"].Select("ColumnA = " + item");
            dr[0]["ColumnB"] = item;
        }
        else
        {
            dataTable1.Rows.Add(null, item);
        }
    }
