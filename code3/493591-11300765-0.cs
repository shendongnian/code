    private void MoveListBoxItems(ListBox from, ListBox to)
    {
        for(int i = 0; i < from.Items.Count; i++)
        {
            if (from.Items[i].Selected)
            {
                to.Items.Add(from.SelectedItem);
                from.Items.Remove(from.SelectedItem);
                // should probably be this:
                to.Items.Add(from.Items[i]);
                from.Items.Remove(from.Items[i]);
            }   
        }
        from.SelectedIndex = -1;
        to.SelectedIndex = -1;
    }
