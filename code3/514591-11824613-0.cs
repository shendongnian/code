            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable("DataTableNo1"));
            ds.Tables.Add(new DataTable("DataTableNo2"));
            string dtname = comboBox1.Text;
            ds.Tables[dtname].Rows.Add(new DataRow());
