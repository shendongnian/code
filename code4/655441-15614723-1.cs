    Form1 form = new Form1();
    form.comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
    string cpuCount = string.Empty; 
...
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
          cpuCount = ((ComboBox)sender).SelectedItem.ToString();
    }
