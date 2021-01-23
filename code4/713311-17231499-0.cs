    static void Main(string[] args)
    {
        DataSet dataset = new DataSet();
        dataset.Tables.Add(new DataTable("table1"));
        dataset.Tables[0].Columns.Add(new DataColumn("Value", typeof(string)));
        dataset.Tables[0].Rows.Add("10");
        dataset.Tables[0].Rows.Add("52");
        DataTable table = dataset.Tables[0];
        DataView view = table.DefaultView;
        var condition1 = table.AsEnumerable().Any(r => r.Field<string>("Value") == "52");
        var condition2 = view.Cast<DataRowView>().Any(rv => rv.Row.Field<string>("Value") == "52");
        Console.WriteLine(String.Format("Result querying datatable: '{0}'. Result using dataview:'{1}'", condition1, condition2));
         Console.ReadLine();
    }
