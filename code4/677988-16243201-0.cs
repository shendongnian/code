    private string _title;
    public string Title 
    {
       get { return _title; }
       set
       {
          _title= value;
          UpperTitle = Title.ToUpper();
       }
    }
    public string UpperTitle { get; protected set; }
