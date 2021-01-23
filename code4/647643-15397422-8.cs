    public string Name 
    {
         get { return name; }
         set 
         {
            name = value;
            onPropertyChanged(this, "allPersonClass");
         }
    }
    <TextBox Text="{Binding Path=Name}" .....
