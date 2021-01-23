            private void SaveAllListItems()
            {
                string listItems = string.Empty;
                foreach (var listBoxItem in listBox1.Items)
                {
    
                    listItems += listBoxItem.ToString();
                    if (listBox1.Items.IndexOf(listBoxItem) > 0 && listBox1.Items.IndexOf(listBoxItem) < listBox1.Items.Count - 1)
                    {
                        listItems += ", ";
                    }
                }
    
                InsertUser(textBox1.Text, comboBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text,
                           textBox6.Text, textBox7.Text, textBox8.Text, listItems);
            }
