        private void MoveListBoxItems(ListBox source, ListBox destination)
        {
            ListBox.SelectedObjectCollection sourceItems = source.SelectedItems;
            foreach (var item in sourceItems)
            {
                destination.Items.Add(item);
            }
            while (source.SelectedItems.Count > 0)
            {
                source.Items.Remove(source.SelectedItems[0]);
            }
        }
        private void first2second_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(FirstListbox, LastListbox);
        }
        private void second2first_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(LastListbox, FirstListbox);
        }
