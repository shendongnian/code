    string ConnString= "Data Source=.\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Pooling=False";
    private void button1_Click(object sender, EventArgs e)
    {
        for(int i=0; i< dataGridView1.Rows.Count;i++)
        {
            string StrQuery= @"INSERT INTO tableName VALUES (" + dataGridView1.Rows[i].Cells["ColumnName"].Value +", " + dataGridView1.Rows[i].Cells["ColumnName"].Value +");";
          try
          {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand comm = new SqlCommand(StrQuery, conn))
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
            }
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
    }
