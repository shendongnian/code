    public Form2(DataColumnCollection dcc)
    {
        DataTable mytable1 = new DataTable();            
        foreach (DataColumn dc in coll)
            {
                mytable1 .Columns.Add(dc);
            }
        InitializeComponent();
    }
