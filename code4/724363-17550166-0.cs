    //GetValueOrDefault()
    private int? createdBy;
    
    public int CreatedBy 
    {
      get { return createdBy.GetValueOrDefault(-1); }
      set { createdBy= value; }
    }
