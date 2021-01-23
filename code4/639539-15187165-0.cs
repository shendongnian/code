        private void addSoftware()
        {
            int x = listBox1.SelectedIndex;
            try
            {
                if (listBox1.Items.Count > 0)
                {
                    listBox2.Items.Add(listBox1.SelectedItem.ToString());
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = listBox2.Items.Count - 1;
            try
            {
                // Set SelectedIndex to what it was
                listBox1.SelectedIndex = x;
            }
            catch
            {
                // Set SelectedIndex to one below if item was last in list
                listBox1.SelectedIndex = x - 1;
            }
        }
