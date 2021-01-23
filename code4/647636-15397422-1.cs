    public string Name 
    {
         get { return name; }
         set 
         {
            name = value;
            onPropertyChanged(this, "Name");
         }
    }
