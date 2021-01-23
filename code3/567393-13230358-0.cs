                foreach (DataGridViewRow row in orderdetailsDataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int x = 0; x < orderdetailsDataGridView.Rows.Count; x++)
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                               con.Open();
                               cmd.Connection = con;
                               cmd.CommandType = CommandType.StoredProcedure;
                               cmd.CommandText = "OD1";
                               cmd.Parameters.Add("@order_id", SqlDbType.Int).Value = row.Cells[0].Value;
                               cmd.Parameters.Add("@prod_id", SqlDbType.Int).Value = row.Cells[1].Value;
                               cmd.Parameters.Add("@qun", SqlDbType.Int).Value = row.Cells[2].Value;
                               cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = row.Cells[3].Value;
                               cmd.ExecuteNonQuery();
                            }
                            x++;
                        }
                    }
                }
            
