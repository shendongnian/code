    private void FillList()
    {
        _list.BeginUpdate();
        _list.Items.Clear();
    
        for(int i =0 ; i <=9; i++)
            _list.Items.Add(i);
    
        _list.EndUpdate();
    }
    
    private void _button_Click(object sender, System.EventArgs e)
    {
        _list.BeginUpdate();
    
        ListBox.ObjectCollection items = _list.Items;
        int count = items.Count;
    
        for(int i = 0; i < count; i++)
        {
            int integerListItem = (int)items[i];
            integerListItem ++;
            // --- Update The Item
            items[i] = integerListItem;
        }
    
        _list.EndUpdate();
    }
