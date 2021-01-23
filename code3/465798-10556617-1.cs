    for(int i=0; i< dataGridView1.Rows.Count;i++)
      {
        string StrQuery= @"INSERT INTO tableName VALUES (" + dataGridView1.Rows[i].Cells["ColumnName"].Value +", " + dataGridView1.Rows[i].Cells["ColumnName"].Value +");";
      try
      {
          SqlConnection conn = new SqlConnection();
          conn.Open();
              using (SqlCommand comm = new SqlCommand(StrQuery, conn))
              {
                  comm.ExecuteNonQuery();
              }
          conn.Close();
      }
