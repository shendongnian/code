    List<int> _list1 = new List<int>(); //1, 2, 3, 4, 5
    
    foreach (var item in _list1)
    {
        Label lb = new Label { Text = item.ToString() };
        lb.Tag = item;
        lb.Click += CustomFunctionOnClick;
    }
    
    private void CustomFunctionOnClick(object sender, EventArgs e)
    {
        Label l = (Label)sender;
        int item = l.Tag;
    }
