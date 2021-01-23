    public event PropertyChangedEventHandler PropertyChanged;
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }
    protected string _myData = string.Empty;
    public string MyData
    {
        get { return _myData; }
        set { _myData = value; NotifyPropertyChanged("MyData"); }
    }
    protected void NotifyPropertyChanged(string propName)
    {
        var methods = PropertyChanged;
        if(methods != null)
           methods(this, new PropertyChangedEventArgs(propName));
    }
    <Label Content="{Binding MyData}" />
