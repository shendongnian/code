    public string textsource
    {
      get { return a; }
      set
      {
        if (value != a)
        {
          a = value;
          NotifyPropertyChanged("textsource");
        }
      }
    }
