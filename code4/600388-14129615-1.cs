    public int ColTotal
    {
        get 
        { 
          return colTotal; 
        }
        set
        {
          colTotal= value;
          OnPropertyChanged("ColTotal");
        }
    }
