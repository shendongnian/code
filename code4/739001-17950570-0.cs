    private void button10_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["CardSerial"].Value.ToString().Equals(textBox2.Text))
                {
                    dataGridView2.Rows[row.Index].DefaultCellStyle.BackColor = Color.Yellow;
                }
    			else
    			{
    				dataGridView2.Rows[row.Index].Visible = false;
    			}
            }
        }
