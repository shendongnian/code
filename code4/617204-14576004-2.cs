    private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       ComboBox comboBox = (ComboBox) sender;
       aTimer.Interval = double.Parse(ComboBox1.SelectedValue);
    }
