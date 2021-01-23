    private Employee _MyEmployee;
    public Employee MyEmployee {
    get
    {
    return _MyEmployee;
    }
    set
    {
    _MyEmployee = value;
    NotifyPropertyChanged(x=>x.MyEmployee);
    }
