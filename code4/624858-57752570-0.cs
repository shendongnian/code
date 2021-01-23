      private void BindProductsGrid()
            {
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                dt = bl.BindProducts();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i]["Product_id"].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i]["Product_name"].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i]["Quantity"].ToString();
                    }
                }
            }
