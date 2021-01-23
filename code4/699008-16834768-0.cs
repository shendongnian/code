    if (dt == null)
    {
        dt = new DataTable();
        for (int i = 0; i < list.Length; i++)
        {
            var dc = dt.Columns.Add(String.Format("column_{0}", i));
        }
        dataGridView1.DataSource = dt;
        for (int i = 0; i < list.Length; i++)
        {
            dataGridView1.Columns[i].HeaderText = list[i].ToString();
            dataGridView1.Columns[i].DefaultCellStyle.Padding = Padding.Empty;
        }
    }
    else
    {
        if (list.Length != dt.Columns.Count)
        {
            MessageBox.Show("Word length does not match.");
            return;
        }
        var dr = dt.NewRow();
        for (int i = 0; i < list.Length; i++)
        {
            dr[i] = list[i];
        }
        dt.Rows.Add(dr);
    }
