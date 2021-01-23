            private void listBox1_MouseClick(object sender, MouseEventArgs e)
            {
                int totalHeight = listBox1.ItemHeight * listBox1.Items.Count;
                if(e.Y < (totalHeight) && e.Y >= 0)
                {
                    // Item is Selected which user clicked.
                    MessageBox.Show("Selected Index : " + listBox1.SelectedItem.ToString().Trim());
                }
                else
                {
                    // All items are Unselected.
                    listBox1.SelectedIndex = -1;
                    MessageBox.Show("Selected Index : " + listBox1.SelectedItem); // Do NOT use 'listBox1.SelectedItem.ToString().Trim()' here.
                }
            }
