    public object SomeProperty
    {
        get
        {
            return SomeDataModel.SomeProperty;
        }
        set
        {
            if (SomeDataModel.SomeProperty != value)
            {
                SomeDataModel.SomeProperty = value;
                OnPropertyChanged("SomeProperty");
            }
        }
    }
