       private void Calculate_button_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please enter a value to textBox1!");
                return;
            }
            else if(!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please check one radio button!");
                return;
            }
            else if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a value from comboBox!");
                return;
            }
            else
            {
                // Program logic...
            }
        }
