    public MyViewModel()
    {
        //set it as a toggle for example
        FooCommand = new RelayCommand( () => IsChecked = !IsChecked );
     }    
    public ICommand FooCommand { get; private set; }
    public bool  IsChecked
    {
       get { return _isChecked; }
       set { _isChecked = value;
            RaisePropertyChanged("IsChecked"); }
    }
