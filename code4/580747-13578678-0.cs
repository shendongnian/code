    private string _someRandomText;
    public string SomeRandomText {
        get { return _someRandomText; }
        set 
        {
            _someRandomText = value;
            NotifyPropertyChanged("SomeRandomText");
        }
    }
