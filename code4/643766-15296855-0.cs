    static DataTable ToDictionary(List<Dictionary<string, int>> list)
    {
        DataTable result = new DataTable();
        if (list.Count == 0)
            return result;
        
        var columnNames = list.SelectMany(dict=>dict.Keys).Distinct();
        result.Columns.AddRange(columnNames.Select(c=>new DataColumn(c)).ToArray());
        foreach (Dictionary<string,int> item in list)
        {
            var row = result.NewRow();
            foreach (var value in item.Values)
                foreach (var cname in columnNames)
                    row[cname] = value;
            result.Rows.Add(row);
        }
        
        return result;
    }
    static void Main(string[] args)
    {
        List<Dictionary<string, int>> it = new List<Dictionary<string, int>>();
        Dictionary<string, int> dict = new Dictionary<string, int>();
        dict.Add("a", 1);
        dict.Add("b", 2);
        dict.Add("c", 3);
        it.Add(dict);
        dict = new Dictionary<string, int>();
        dict.Add("bob", 34);
        dict.Add("tom", 37);
        it.Add(dict);
        dict = new Dictionary<string, int>();
        dict.Add("Yip Yip", 8);
        dict.Add("Yap Yap", 9);
        it.Add(dict);
    
        DataTable table = ToDictionary(it);
        foreach (DataColumn col in table.Columns)
            Console.Write("{0}\t", col.ColumnName);
        Console.WriteLine();
        foreach (DataRow row in table.Rows)
        {
            foreach (DataColumn column in table.Columns)
                Console.Write("{0}\t", row[column].ToString());
            Console.WriteLine();
        }
        Console.ReadLine();
    
    }
