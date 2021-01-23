       private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //deleting all items
            comboBox1.Items.Clear();
            //adding text of each textbox if not empty
            if (textBox1.Text != "")
                comboBox1.Items.Add(textBox1.Text);
            if (textBox2.Text != "")
                comboBox1.Items.Add(textBox2.Text);
            //if combobox not empty select first item
            if (comboBox1.Items.Count != 0)
                comboBox1.SelectedIndex = 0;
        }
