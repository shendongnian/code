    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
       ComboBox cbx= (ComboBox) sender;
       Button1.Enabled = !string.IsNullOrEmpty(cbx.Text);
    }
