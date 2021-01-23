    private void button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            cs.Open();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
            
                if (!row.IsNewRow)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO datagrid (sr, name, email, tel_no) VALUES(@c1,@c2,@c3,@c4)", conn))
                    {
                    
                        cmd.Parameters.AddWithValue("@C1", row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@C2", row.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@C3", row.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@C4", row.Cells[3].Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
