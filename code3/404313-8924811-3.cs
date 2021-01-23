    DataTable Dt = new DataTable();
                DataColumn Dc = new DataColumn("Name");
                DataColumn Dc1 = new DataColumn("ID");
                Dt.Columns.Add(Dc);
                Dt.Columns.Add(Dc1);
    
                DataRow dr = Dt.NewRow();
                dr["name"] = "1";
                dr["ID"] = "111";
                Dt.Rows.Add(dr);
    
                dr = Dt.NewRow();
                dr["name"] = "2";
                dr["ID"] = "11112";
                Dt.Rows.Add(dr);
    
                Dt.Columns[0].ColumnName = "ddsxsd";
                Dt.AcceptChanges();
