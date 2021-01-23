    public static int MinimumLength
    {
        get { return _MinimumLength; }
        set
        {
            if (_MinimumLength != value)
            {
                _MinimumLength = value;
                OnGlobalPropertyChanged("MinimumLength");
            }
        }
    }
    static event PropertyChangedEventHandler GlobalPropertyChanged = delegate { };
    static void OnGlobalPropertyChanged(string propertyName)
    {
        GlobalPropertyChanged(
            typeof (ExampleClass), 
            new PropertyChangedEventArgs(propertyName));
    }
    public ExampleClass()
    {
        // This should use a weak event handler instead of normal handler
        GlobalPropertyChanged += this.HandleGlobalPropertyChanged;
    }
    void HandleGlobalPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "MinimumLength":
                if (length > MinimumLength)
                    length = MinimumLength;
                break;
        }
    }
