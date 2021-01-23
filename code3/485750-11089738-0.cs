    // Using Students instead of Items for the PropertyName to clarify
    public ObservableCollection<Student> Students { get; set; }
    
    public MyConstructor()
    {
        ...
       
        Students = search.students();
        listBoxSS.DataContext = this;
    }
