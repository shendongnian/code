    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        
            //or
            //button1.Enabled = comboBox1.SelectedValue != null;
        }
