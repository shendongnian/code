    List<DataTable> dts = new List<DataTable>();
    var dt=new DataTable();
    dt.Columns.Add("Test0");
    dt.Rows.Add(1);
    dts.Add(dt);
            
    dt = new DataTable();
    dt.Columns.Add("Test1");
    dt.Rows.Add(2);
    dts.Add(dt);
            
    dt = new DataTable();
    dt.Columns.Add("Test3");
    dt.Rows.Add(3);
    dts.Add(dt);
            
    var destination = new DataTable();
    for (int i = 0; i < dts.Sum(t=>t.Columns.Count); i++)
    {
        destination.Columns.Add(String.Format("column_{0}", i));
    }
    List<object> rowItems=new List<object>();
    for (int i = 0; i < dts[0].Rows.Count; i++)
    {
        for (int j = 0; j < dts.Count; j++)
        {
            rowItems.AddRange(dts[j].Rows[i].ItemArray);
        }
        destination.Rows.Add(rowItems.ToArray());
    }
