    private string _rightSideText = string.Empty;
    public string RightSideText
    {
        get { return _rightSideText; }
        set
        {
            _rightSideText = value;
            OnPropertyChanged("RightSideText");
        }
    }
