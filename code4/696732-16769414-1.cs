    private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        ComboBox comboBox = (ComboBox) sender;
        if(comboBox.SelectedItem != null)
        {
            int id = Convert.ToInt32(comboBox.SelectedItem)
            cbo2.Visible = (id == 3)
        }
    }
