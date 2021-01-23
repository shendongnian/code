    private void comboBox1_Leave(object sender, EventArgs e)
    {
        ComboBox cb = (ComboBox)sender;
        if (! cb.Items.Contains(cb.Text))
        {
            MessageBox.Show("No Item is Selected");
        }
    }
