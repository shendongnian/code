       protected void removeButton_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem.Text == null)
            {
                MessageBox.Show("Please select an item for deletion.");
            }
            else
            {
                for (int i = 0; i <= ListBox1.Items.Count - 1; i++)
                {
                    if (ListBox1.Items[i].Selected)
                    {
                        DeleteRecord(ListBox1.Items[i].Value.ToString());
                    }
                }
                string remove = ListBox1.SelectedItem.Text;
                ListBox1.Items.Remove(remove);
            }
        }
