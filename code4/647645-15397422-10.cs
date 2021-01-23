    public string Name 
    {
         get { return name; }
         set 
         {
            name = value;
            onPropertyChanged(this, "Name");
            onPropertyChanged(this, "Display");
         }
    }
    
    public string Surname
    {
         get { return surname; }
         set 
         {
            surname= value;
            onPropertyChanged(this, "Surname");
            onPropertyChanged(this, "Display");
         }
    }
    
    public string Display
    {
         get { return Name + " " + Surname; }
    }
