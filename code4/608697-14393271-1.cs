        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Helper.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ToDeleteEmpDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        if ((bool)item.Cells[1].Value) //<--Where: The ColumnIndex of the DataGridViewCheckBoxCell
                        {
                            cmd.Parameters.Add("@sno", SqlDbType.Int).Value = item.Cells[0].Value; //<--Where: The ColumnIndex of the Primary key from your DataGridView
                        }
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
