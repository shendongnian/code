       private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = ListBox.SelectedItem;
                var check = comboBox1.Items.Cast<string>()
                     .ToList()
                     .FirstOrDefault(c => c.Contains(selectedItem));
                if (check != null)
                {
                    ComboBox.Items.Add("Chicken McNuggets");
                }
                else
                {
                    ListBox.Items.Remove(selectedItems);
                }
            }
            catch
            {
                //MessageBox.Show();
            }
        }
