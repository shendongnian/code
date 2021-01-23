     SqlConnection con = new SqlConnection(/*YOUR Connection Path*/);
                foreach (DataGridViewRow Row in dataGridView1.Rows)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Service_Sub(Service_No,Service_Date) Values('" + Row.Cells[0].Value.ToString() + "','" + Row.Cells[1].Value.ToString() + "')",con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
