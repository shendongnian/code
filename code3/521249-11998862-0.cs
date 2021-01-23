            DataTable dt = GetTable(true);
            dataGridView1.DataSource = dt;
           
            DataRow row = dt.NewRow();
            row[0] = 101;
            row[1] = "101";
            row[2] = "101";
            row[3] = DateTime.Now;
            dt.ImportRow(row);
            DataTable dt2 = GetTable(false);
            object[] r = { 105, "Habib", "Zare", DateTime.Now };
            dt2.Rows.Add(r);
            dt2.ImportRow(dt.Rows[1]);
            dataGridView2.DataSource = dt2;
