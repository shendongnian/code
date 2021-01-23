    private UserControl _currentpage
    public UserControl CurrentPage { 
        get
        {
            return _currentpage;
        }
        set
        {
           if (PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs("CurrentPage"));
        } 
    }
    public ViewModel()
    {
        CurrentPage = new FirstPage();
    }
    private void NextPageExecuted(object parameter)
    {
         //Logic that picks the next page from a set of pages
    }
    private void PrevPageExecuted(object parameter)
    {
         //Logic that picks the previous page from a set of pages
    }
