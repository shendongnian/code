        private bool afterRemove = false;
        void lbMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (afterRemove)
            {
                afterRemove = false;
                return;
            }
            DialogResult result = new DialogResult();
    
            result = MessageBox.Show("Are you sure you want to remove this item?", "Removal Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
    
            if (result == DialogResult.Yes)
            {
                afterRemove = true;
                lbMessage.Items.Remove(lbMessage.SelectedItem); 
                // Another call to "lbMessage_SelectedIndexChanged" is made right here.
           }
        }
    
        private void btnAddMessage_Click(object sender, EventArgs e)
        {
            lbMessage.Items.Add(txtMessage.Text);
            txtMessage.Text = string.Empty;
        }
