      private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = string.Empty;
            string s1 =string.Empty;
            if (comboBox2.SelectedItem != null)
            {
                s1 = comboBox2.SelectedItem.ToString();
            }
            if (comboBox1.SelectedItem != null)
            {
                s = comboBox1.SelectedItem.ToString();
            }
            if (s == s1)
            {
                MessageBox.Show("You have Selected These Item As Second Combobox");
                comboBox1.SelectedItem = null;
            }
        }
        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s=string.Empty;
            string s1 = string.Empty;
            if (comboBox1.SelectedItem != null)
            {
                s = comboBox1.SelectedItem.ToString();
            }
            if (comboBox2.SelectedItem != null)
            {
                s1 = comboBox2.SelectedItem.ToString();
            }
            if (s == s1)
            {
                MessageBox.Show("You have Selected These Item As First Combobox");
                comboBox2.SelectedItem = null;
            }
        }
