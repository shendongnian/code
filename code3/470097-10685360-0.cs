    DataSet Ds = new DataSet();
    DataTable Dt = new DataTable();
                
    Ds.Tables.Add(Dt);
    Dt.Columns.Add(new DataColumn("String A", typeof(string)));                
    Dt.Columns.Add(new DataColumn("Int 1", typeof(int)));      
          
    Dt.Rows.Add(new object[] { "Patricia", 3 });
    Dt.Rows.Add(new object[] { "John", 4 });
    Dt.Rows.Add(new object[] { "Mayer", 5 });
