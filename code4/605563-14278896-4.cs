    System.Data.DataTable dt = new System.Data.DataTable();
    dt.Columns.Add("Col1", typeof(int));
    dt.Rows.Add(1);
     
    System.Data.DataTable dt2 = new System.Data.DataTable();
    dt2.Columns.Add("Col1", typeof(string));
    dt2.Load(dt.CreateDataReader(), System.Data.LoadOption.OverwriteChanges);
