    private bool countLabelVisible;
    public bool CountLabelVisible
    {
      get
      {
        return countLabelVisible;
      }
      set
      {
       if (countLabelVisible != value)
       {
          countLabelVisible = value;
          RaisePropertyChanged(() => CountLabelVisible);
       }
    }
    
