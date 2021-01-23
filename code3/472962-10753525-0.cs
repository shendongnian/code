    //On item selected in ComboBox1
    private void showSelectedButton_Click(object sender, System.EventArgs e) 
    {
        
        comboBox2.Items.Remove(comboBox1.SelectedIndex.ToString());
        comboBox3.Items.Remove(comboBox1.SelectedIndex.ToString());
        comboBox4.Items.Remove(comboBox1.SelectedIndex.ToString());
    }
