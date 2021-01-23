    private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox senderComboBox = (ComboBox) sender;
    
        if (senderComboBox.SelectionLength > 0)
        {
            if (senderComboBox.SelectedItem.ToString() == "OK")
            {
                cb[ii].ForeColor = Color.Black;
            }
            else
            {
                cb[ii].ForeColor = Color.Red;
            }
        }
    }
