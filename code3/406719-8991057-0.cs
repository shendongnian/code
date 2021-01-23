    ICommand MyCommand { get; set; }
    
    MyCommand = new RelayCommand<object>(
        param => DoCopyToChildrenCommand<T, U>(param as T),
        param => param is T);
