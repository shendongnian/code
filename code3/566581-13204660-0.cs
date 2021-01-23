    DataTable dtOutMrkTbl = new DataTable();
    dtOutMrkTbl.Load(rdr3);
    dtOutMrkTbl.TableName = "OutOfMarkTable";
    ds.Tables.Add(dtOutMrkTbl);
    GridView1.DataSource = ds.Tables["OutOfMarkTable"]; // or use the index instead
