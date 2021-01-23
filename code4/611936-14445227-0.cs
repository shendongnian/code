            //create some data...
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(decimal));
            dt.Columns.Add("Name");
            DataRow r1 = dt.NewRow();
            r1[0] = 243546.45;
            r1[1] = "Demo";
            dt.Rows.Add(r1);
            DataRow r2 = dt.NewRow();
            r2[0] = 2;
            r2[1] = "Data";
            dt.Rows.Add(r2);
            //populate gridview...
            dataGridView1.DataSource = dt;
