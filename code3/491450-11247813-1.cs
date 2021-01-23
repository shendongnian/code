    static void Main(string[] args)
    {
        fooDataSet fooDataSet = new fooDataSet();
        fooDataSetTableAdapters.barTableAdapter barTableAdapter = new fooDataSetTableAdapters.barTableAdapter();
    
        barTableAdapter.Fill(fooDataSet.bar);
    
        var myDataTable = barTableAdapter.GetData().AsEnumerable();
    
        var bnl = from results in myDataTable
                  select results;
    
        Console.ReadLine();
    }
