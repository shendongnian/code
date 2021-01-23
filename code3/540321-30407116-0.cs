            string filepath = @"C:\1.xlsx";
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + @";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text""";
            OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", conn);
            DataSet ds = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(ds);
            // above code block is yours as is.
            // below part is for sorting.
            DataTable data = ds.Tables[0];
            data.Columns.Add(new DataColumn("Guid"));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i].SetField("Guid", Guid.NewGuid());
            }
            DataView dv = data.DefaultView;
            dv.Sort = "Guid desc";            
            showdata.DataSource = dv.ToTable();
