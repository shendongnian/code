    public int GetLength
    {
        get
        {
            return CheckListBox.Items.Cast<ListItem>().Where(
                                         i => i.Selected).ToList().Count;
        }
    }
