    public ObservableCollection<IdObject> items
    {
        get { return (ObservableCollection<IdObject>)GetValue(ApplicationsProperty); }
        set { SetValue(ApplicationsProperty, value); }
    }
	
	items = new ObservableCollection<IdObject>();
