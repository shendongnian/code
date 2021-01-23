    static void Main(string[] args)
    {
        int[] data = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        DataTable dt = CreateDataTable(data);
        int omarks = Convert.ToInt32(dt.Compute("Sum(MarksInt)", ""));
        string text = omarks.ToString();
        
        Console.WriteLine(omarks == data.Sum());
    }
        
    static DataTable CreateDataTable(IEnumerable<int> data)
    {
        DataTable table = new DataTable();
        
        table.Columns.Add("Marks", typeof(string));
        table.Columns.Add("MarksInt", typeof(int), "Convert(Marks, 'System.Int32')");
        
        foreach (int i in data)
        {
            DataRow row = table.NewRow();
            row["Marks"] = i.ToString();
        
            table.Rows.Add(row);
        }
        
        return table;
    }
