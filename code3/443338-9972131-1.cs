    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    dt.Columns.Add("Name");
    dt.Columns.Add("SubReport");
    foreach (MyObject myo in list_of_myobjects)
    {
     foreach (MySubObject myso in myo.SubObjects)
     {
      DataRow dr = dt.NewRow();
      dr[0] = myo.Name;
      dr[1] = myso.SubName;
      dt.Rows.Add();
      ds.Tables.Add(dt);
     }
    }
