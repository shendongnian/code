    public string SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            var oldItem=_selectedItem;
            _selectedItem=value;
            OnPropertyChanged("SelectedItem")
            if (!SomeCondition(value)) //If does not satisfy condition, set item back to old item
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => SelectedItem = oldItem),
                                                     DispatcherPriority.ApplicationIdle);
        }
    }
