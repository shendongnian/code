       private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedItems = listBox1.SelectedItem.ToString();
                var check = comboBox1.Items.Cast<string>()
                     .ToList()
                     .FirstOrDefault(c => c.Contains(selectedItems));
                if (check != null)
                {
                }
                else
                {
                    comboBox.Items.Add("Chicken McNuggets");
                    listBox1.Items.Remove(selectedItems);
                }
            }
            catch
            {
                //MessageBox.Show();
            }
        }
