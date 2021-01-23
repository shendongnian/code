    DataTable dt = new DataTable();
    for (int i = 0; i < GridView1.Columns.Count; i++)
        {
            dt.Columns.Add("column"+i.ToString());
        }
    foreach (GridViewRow row in GridView1.Rows)
        {
            DataRow dr = dt.NewRow();
            for(int j = 0;j<GridView1.Columns.Count;j++)
                {
                    dr["column" + j.ToString()] = row.Cells[j].Text;
                }
                    
                dt.Rows.Add(dr);
        }
