       private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // a checkbox is changing
            // but value is not updated yet
        }
        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine(checkedListBox1.CheckedItems.Count);
            Debug.WriteLine(checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[0]));
        }
