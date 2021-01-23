    private List<object> _addedItems = new List<object>();
    void flcl_Selection(object sender, MyEventArgs e)
    {
        //remove children here     
        foreach(var item in _addedItems)
        {
            MainGrid.Children.Remove(item);
        }
        _addedItems = new List<object>();
        for (int i = 0; i < e.MyFirstString.Count; i ++)
        {
            LabelCountry lbl = new LabelCountry((string)e.MyFirstString[i]);
            MainGrid.Children.Add(lbl);
            _addedItems.Add(lbl);
        }
    }
