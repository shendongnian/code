            DataTable dt = new DataTable();
            dt.Columns.Add("Column One");
            dt.Rows.Add(new object[] { "Item1" });
            dt.Rows.Add(new object[] { "Item2" });
            dt.Rows.Add(new object[] { "Item3.3" });
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.Columns.Clear();
            //dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
