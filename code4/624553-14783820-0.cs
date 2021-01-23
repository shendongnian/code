    public ObservableCollection<string> MyList { get; set; }
    
    public void SomeMethod()
    {
        MyList = new ObservableCollection<string>();
        RaisePropertyChanged("MyList");
    }
