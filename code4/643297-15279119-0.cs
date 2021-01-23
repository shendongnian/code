    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    
    dt1.Columns.Add("Col");
    dt2.Columns.Add("Col");
    
    for (int i = 0; i < 10; i++)
    {
    	DataRow dr = dt1.NewRow();
    	dr["Col"] = i.ToString();
    	dt1.Rows.Add(dr);
    }
    
    for (int i = 5; i < 15; i++)
    {
    	DataRow dr = dt2.NewRow();
    	dr["Col"] = i.ToString();
    	dt2.Rows.Add(dr);
    }
    
    var result = dt1.AsEnumerable().Intersect(dt2.AsEnumerable(), DataRowComparer.Default);
    
    dataGridView1.DataSource = dt1;
    dataGridView2.DataSource = dt2;
    
    for (int i = 0; i < dataGridView1.RowCount -1; i++)
    {
    	DataRow currRow = ((DataRowView)dataGridView1.Rows[i].DataBoundItem).Row;
    	if (result.Contains(currRow))
    		dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
    }
