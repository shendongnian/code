    private void dataGridViewProducts_Paint(object sender, PaintEventArgs e)
            {
                foreach (DataGridViewRow row in dataGridViewProducts.Rows)
                {
                    int value = Convert.ToInt32(row.Cells["Quantity"].Value);
                    if (value == 0)
                        row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
 
