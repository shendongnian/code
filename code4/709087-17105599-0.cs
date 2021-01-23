    private void buttonRemove_Click(object sender, EventArgs e) {
            if (listBox1.SelectedIndex == -1) { // Not Selected Anything
                MessageBox.Show("Select an item to delete");
            }
            else {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex); // Remove item
            }
        }
