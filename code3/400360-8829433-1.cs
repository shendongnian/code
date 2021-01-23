    void lbMessage_SelectedIndexChanged(object sender, EventArgs e)
    {
      if(lbMessage.SelectedIndex == -1)
        return;
        DialogResult result = new DialogResult();
        result = MessageBox.Show("Are you sure you want to remove this item?", "Removal Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (result == DialogResult.Yes)
        {
            lbMessage.Items.Remove(lbMessage.SelectedItem); 
            lbMessage.SelectedIndex = -1;
        }
    }
