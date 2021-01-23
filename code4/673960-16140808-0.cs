    public MyType1 _selectedItem1;
    public MyType1 SelectedItem1
    {
        get { return _selectedItem1; }
        set 
        {
            if (_selectedItem1 == value) return;
            _selectedItem1 = value;
            //replace with string implementation, if needed
            OnPropertyChanged(() => SelectedItem1);
            if (_selectedItem1 == ...)
            {
                ItemsSource2 = new List<MyClass2> { ... };
            }
            else if (_selectedItem1 == ...)
            {
                ...
            }
        }
    }
    public IList<MyType2> _itemsSource2;
    public IList<MyType2> ItemsSource2
    {
        get { return _itemsSource2; }
        set 
        {
            if (_itemsSource2 == value) return;
            _itemsSource2 = value;
            OnPropertyChanged(() => ItemsSource2);
        }
    }
