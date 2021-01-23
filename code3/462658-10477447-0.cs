    int sum = 0;
    
    for (int i = 0; i < dt.Rows.Count - 1; i++)
    {
        sum += int.Parse(dataGridView1.Rows[i].Cells["Fee"].Value.ToString());
    }
    
    DataSet ds = new DataSet();
    adapter.Fill(ds);
    DataRow row = ds.Tables["Entry"].NewRow();
    row[0] = "";
    row[1] = "";
    row[2] = sum;
    ds.Tables["Entry"].Rows.Add(row);
