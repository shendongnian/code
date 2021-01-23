    public ICommand Command
    {
      get
      {
        return (ICommand) this.GetValue(RibbonGallery.CommandProperty);
      }
      set
      {
        this.SetValue(RibbonGallery.CommandProperty, (object) value);
      }
    }
