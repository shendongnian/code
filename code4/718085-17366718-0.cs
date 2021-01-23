    void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex == -1)
                {
                    if (dataGridView1.DataSource != null)
                    {
                        BindingContext[dataGridView1.DataSource].Position = 0;
                    }
                }
            }
