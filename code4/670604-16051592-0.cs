    private string name;
    public string Name
    {
       get { return name; }
       set
       {
           if( name != value )
           {
               name = value;
               OnPropertyChanged("Name");
           }
       }
    }
