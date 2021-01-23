    public ObservableCollection<SomeObject> SomeCollection
    {
        get 
        {
            if (_someCollection == null)
            {
                _someCollection = new ObservableCollection<SomeObject>();
            }
            return _someCollection; 
        }
    }
