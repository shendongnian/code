        private void button1_Click(object sender, EventArgs e)
        {
            if (ListBox.SelectedIndex != -1)
            {
                // ... display the dialog ...
                Console.WriteLine(ListBox.SelectedItem.ToString());
            }
        }
