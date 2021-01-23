    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(yesnocomboBox.SelectedIndex == 0)
        {
            label1.Visible = true;
            otherItem.Visible = true;
            anotherItem.Visible = false;
        }
    }
