    DataTable dt = new DataTable();
    dt.Columns.Add("Column 1", typeof(DoubleOrText));
    
    dt.Rows.Add(new DoubleOrText(0.0, null));
    dt.Rows.Add(new DoubleOrText(1.0, "X"));
    dt.Rows.Add(new DoubleOrText(2.3, "-"));
    dt.Rows.Add(new DoubleOrText(4.1, null));
    
    this.dataGridView1.DataSource = dt;
