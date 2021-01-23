    private void dgv_items_RowEnter(object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    // tempValue is a class var
                    tempValue = dgv_items.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                catch (Exception ex) { 
                    MessageBox.Show(ex.Message);
                }
            }
