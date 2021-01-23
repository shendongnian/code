    string StrQuery;
    try
    {
        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;
                conn.Open();
                for(int i=0; i< dataGridView1.Rows.Count;i++)
                {
                    StrQuery= @"INSERT INTO tableName VALUES (" 
                        + dataGridView1.Rows[i].Cells["ColumnName"].Text+", " 
                        + dataGridView1.Rows[i].Cells["ColumnName"].Text+");";
                    comm.CommandText = StrQuery;
                    comm.ExecuteNonQuery();
                }
            }
        }
    }
