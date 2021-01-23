    private void dataGridViewItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                e.Control.KeyPress -= new KeyPressEventHandler(itemID_KeyPress);//This line of code resolved my issue
                if (dataGridViewItems.CurrentCell.ColumnIndex == dataGridViewItems.Columns["itemID"].Index)
                {
                    TextBox itemID = e.Control as TextBox;
                    if (itemID != null)
                    {
                        itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
                    }
                }
            }
    
    private void itemID_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
