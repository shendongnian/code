    public ObservableCollection<SomeObject> SomeCollection
    {
        get { return _someCollection; }
        set 
        {
            if (value != _someCollection)
            {
                _someCollection = value;
                RaisePropertyChanged(() => this.SomeCollection);
            }
        }
    }
