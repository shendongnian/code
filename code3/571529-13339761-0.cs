        private void saveButton_Click(object sender, EventArgs e)
        {
            // Get value from textBox
            int number = Int32.Parse(textBox1.Text);
  
            // Get value from combobox
            int selcetedComboValue = Int32.Parse(comboBox1.SelectedItem.ToString());
            // Validate Values
            if (selcetedComboValue <= 5)
            {
                if (number <= 6)
                {
                    // Valid Number 
                }
                else
                {
                    // Invalid Number
                }
            }
            else if (selcetedComboValue <= 10)
            {
                if (number <= 12)
                {
                    // Valid Number
                }
                else
                {
                    // Invalid Number
                }
            }
        }
