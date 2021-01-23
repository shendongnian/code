    private string owner = "I am the Owner";
    public string Owner
    {
      get { return owner; }
      set 
      { 
           owner=value;
           NotifyPropertyChanges("Owner");
      }
    }
