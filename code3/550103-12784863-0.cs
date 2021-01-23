    private void btnkaladel_Click(object sender, EventArgs e)
            {
                if (MessageBox.Show("Are you sure to delete?", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
    
                    dataGridViewkala.Rows.RemoveAt(dataGridViewkala.CurrentRow.Index);
                    bk.deletekala(int.Parse(txtkalacode.Text));
                    dataGridViewkala.DataSource = dt;
                    txtkalacode.Text = null;
                    txtkalaname.Text = null;
                    txtkalapoint.Text = null;
                    txtkqty.Text = null;
                }
            }
    
            
    
            private void dataGridViewkala_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                txtkalacode.Text = dataGridViewkala.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtkalaname.Text = dataGridViewkala.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtkqty.Text = dataGridViewkala.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtkalapoint.Text = dataGridViewkala.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
    
            private void btnedit_Click(object sender, EventArgs e)
            {
                if (MessageBox.Show("Are you sure to edit?", "editing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bk.updatekala(int.Parse(txtkalacode.Text), txtkalaname.Text, int.Parse(txtkqty.Text),
                                  int.Parse(txtkalapoint.Text));
                    dt = bk.Getdata();
                    dataGridViewkala.DataSource = dt;
                    txtkalacode.Text = null;
                    txtkalaname.Text = null;
                    txtkalapoint.Text = null;
                    txtkqty.Text = null;
                }
            }
    
           
        }
