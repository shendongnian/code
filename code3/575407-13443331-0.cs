    public string Name
    {
       get { return name; }
       set
       {
          name = value;
          if(UpdateUI) // Your condition here
          {
             OnPropertyChanged("Name");
          }
       }
    }
