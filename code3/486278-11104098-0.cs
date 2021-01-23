    private Lazy<string> nameProxy; 
    private string name;
    public string Name 
    { 
      get 
      {
        if(name==null)
        {
          name = nameProxy.Value;
          nameProxy = null;
        }
        return name;
      } 
    } 
