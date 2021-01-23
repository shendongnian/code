    static void Main(string[] args)
    {
        var dt = new DataTable("Data");
        var dtOrder = new DataTable("Order");
        // Insert some data here
        int i = 0;
        var orderDict = new Dictionary<object, int>();
        foreach(DataRow row in dtOrder.Rows)
        {
            orderDict.Add(row["Key"], ++i);
        }
        var ordered = dt.Rows.Cast<DataRow>().OrderBy(r => orderDict[r["Key"]]);
    }
