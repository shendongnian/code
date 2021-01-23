    public string Name 
    {
         get { return name; }
         set 
         {
            name = value;
            onPropertyChanged(this, "Name");
         }
    }
    <TextBox Text="{Binding Path=Name, UpdateSourceTrigger=PropertyChanged}" .....
