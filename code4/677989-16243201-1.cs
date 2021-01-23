    private string _title;
    public string Title 
    {
       get { return _title; }
       set
       {
          _title= value;
          UpperTitle = string.IsNullOrEmpty(_title)? string.Empty : _title.ToUpper();
       }
    }
    public string UpperTitle { get; protected set; }
