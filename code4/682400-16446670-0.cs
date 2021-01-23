    public void TestFirstName()
    {
        foreach (var item in MyFlipView.Items)
	    {
            var _Container = MyFlipView.ItemContainerGenerator
                .ContainerFromItem(item);
            var _Children = AllChildren(_Container);
            var _FirstName = _Children
                // only interested in TextBoxes
                .OfType<TextBox>()
                // only interested in FirstName
                .First(x => x.Name.Equals("FirstName"));
            // test & set color
            _FirstName.Background = 
                (string.IsNullOrWhiteSpace(_FirstName.Text))
                ? new SolidColorBrush(Colors.Red)
                : new SolidColorBrush(Colors.White);
	    }
    }
    public List<Control> AllChildren(DependencyObject parent)
    {
        var _List = new List<Control>();
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var _Child = VisualTreeHelper.GetChild(parent, i);
            if (_Child is Control)
                _List.Add(_Child as Control);
            _List.AddRange(AllChildren(_Child));
        }
        return _List;
    }
