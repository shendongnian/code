    DataTable dt = new DataTable();
    for (int i = 0; i < 10; i++)
    {
       dt.Columns.Add(i.ToString());
    }    
    for (int j = 0; j < 200000; j++)
    {
       DataRow row = dt.NewRow();
       for (int k = 0; k < 10; k++)
       {
          row[k] = Guid.NewGuid().ToString();
       }
       dt.Rows.Add(row);
    }
    dataGridView1.DataSource = dt;
