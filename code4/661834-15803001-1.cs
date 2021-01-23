    private string _name;
    public string Name{
      set{
        _name = value;
        OnPropertyChanged("Name");
      }
    }
