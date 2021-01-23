        Try
           {
             con.Open();
                string order= txt_orderno.Text;
                SqlCommand cmd = new SqlCommand("gridalldata", con);
                   cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@order_no", SqlDbType.NVarChar).Value=order;
                SqlDataReader dr = cmd.ExecuteReader();
                 for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                if (dr.HasRows)
                {
                    dr.Read();
                    dataGridView1.Rows[i].Cells[0].Value = dr[0].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr[2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr[3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr[4].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr[5].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = dr[6].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = dr[7].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = dr[8].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = dr[9].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = dr[13].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = dr[12].ToString();
                    }
                    }
                dr.Close();
                con.Close();
            }
