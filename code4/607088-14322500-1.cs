    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                button1.Enabled = false;
            else
                button1.Enabled = true;
        
            //or
            //button1.Enabled = comboBox1.SelectedIndex == -1;
        }
