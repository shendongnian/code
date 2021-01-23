    public bool CanAcceptButton
    {
      get { return true; /* add logic here */ }
    }
    
    public void AcceptButton()
    {
      TryClose(true);
    }
    
    public bool CanCancelButton
    {
      get { return true; }
    }
    
    public void CancelButton()
    {
      TryClose(false);
    }
