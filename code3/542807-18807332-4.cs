    public const string IsOpenPropertyName = "IsOpen";
    
    private bool isOpen = false;
    
    /// <summary>
    /// Sets and gets the IsOpen property.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// </summary>
    public bool IsOpen
    {
      get
      {
        return isOpen;
      }
      set
      {
        RaisePropertyChanging(IsOpenPropertyName);
        isOpen = value;
        RaisePropertyChanged(IsOpenPropertyName);
      }
    }
