    public Foo() 
    {
        ResultCollection = new ObservableCollection<Result>();
    }
    [...]
    
    public ObservableCollection<Result> ResultCollection { get; private set; }
