    private string owner = "I am the Owner";
    public string Owner
    {
      get { return owner; }
      set 
      { 
            if(!string.IsNullOrEmpty(value))
                  owner=value;
      }
    }
