       private void dataGridViewItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var itemID = e.Control as TextBox;
            if (dataGridViewItems.CurrentCell.ColumnIndex ==  1) //Where the ColumnIndex of itemIDyour
            {
                if (itemID != null)
                {
                    itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
                    itemID.KeyPress -= new KeyPressEventHandler(itemID_KeyPress);
                }
            }
        }
    
        private void itemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
