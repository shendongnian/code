    public string OwnerPassword
    {
      set { SecurityHandler.OwnerPassword = value; }
    }
    /// <summary>
    /// TODO: JOSH
    /// </summary>
    public bool MaintainOwnerAndUserPassword
    {
        get { return SecurityHandler.MaintainOwnerAndUserPassword; }
        set { SecurityHandler.MaintainOwnerAndUserPassword = value; }
    }
