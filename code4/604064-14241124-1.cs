            BindingSource bs = new BindingSource();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            dt.Columns.Add("1", typeof(int));
            dt.Columns.Add("2");
            dt.Columns.Add("3");
            dt.Columns.Add("4");
            dt.Columns.Add("5");
            
            string[] row = {null,"dsadxaxsa","xasxsa","","dsad"};
            string[] row1 = { "1", "ddd", "gg", "hh", "ff" };
            string[] row2 = { "2", "h", "hhhh", "sas", "dsad" };
            string[] row3 = { "3", "h", "hhhh", "sas", "dsad" };
            string[] row4 = { null, "h", "hhhh", "sas", "dsad" };
            dt.Rows.Add(row);
            dt.Rows.Add(row1);
            dt.Rows.Add(row2);
            dt.Rows.Add(row3);
            dt.Rows.Add(row4);
           
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            ds.Tables.Add(dt);
            ds.WriteXml("e:\\results.xml", System.Data.XmlWriteMode.IgnoreSchema);
