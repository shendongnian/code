    if (listBox1.Items.Contains(listBox2.SelectedItem))
            {
                MessageBox.Show("ListBox already contains Item");
            }
            else
            {
                listBox1.Items.Add(listBox2.SelectedItem);
            }
