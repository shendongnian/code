    List<DataGridViewRow> rowstodelete = new List<DataGridViewRow>();
    
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        DataGridViewRow dr = dataGridView1.Rows[i];
        if (dr.Selected)
        {
            rowstodelete.Add(dr);
            try
            {
                  con.Open();
                  cmd.CommandText = "Delete from motociclete where codm=" + i + "";
                  cmd.ExecuteNonQuery();
                  con.Close();
             }
             catch (Exception ex)
             {
                   MessageBox.Show(ex.ToString());
             }
        }
    }
    
    foreach (DataGridViewRow row in rowstodelete)
    {
        dataGridView1.Rows.Remove(row);
    }
