    public ObservableCollection<Files> Filescollection {get;set;}
        
    public MainViewModel()
    {
        this.Filescollection = new ObservableCollection<Files>();
        SelectFilesAction();
    }
    
    private void SelectFilesAction()
    {
       Filescollection.Add(new Files { Name = "index.html", Path = "C:\\Files"});
    }
