    // This is your private variable and its public property
    private double _myWidth;
    public double MyWidth
    {
        get { return _myWidth; }
        set { SetField(ref _myWidth, value, "MyWidth"); } // You could use "set { _myWidth = value; RaisePropertyChanged("MyWidth"); }", but this is cleaner. See SetField<T>() method below.
    }
    // Feel free to add as much properties as you need and bind them. Examples:
    private double _myHeight;
    public double MyHeight
    {
        get { return _myHeight; }
        set { SetField(ref _myHeight, value, "MyHeight"); }
    }
    private string _myText;
    public double MyText
    {
        get { return _myText; }
        set { SetField(ref _myText, value, "MyText"); }
    }
    // This is the implementation of INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(String propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    // Prevents your code from accidentially running into an infinite loop in certain cases
    protected bool SetField<T>(ref T field, T value, string propertyName)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
        field = value;
        RaisePropertyChanged(propertyName);
        return true;
    }
