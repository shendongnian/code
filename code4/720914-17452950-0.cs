    public CultureInfo CurrentUICulture
    {
      get { return Properties.Resources.Culture; }
      set
      {
        Properties.Resources.Culture = value;
       
        OnPropertyChanged("Title");
        OnPropertyChanged("Description");
        OnPropertyChanged("FarenheitLabel");
        OnPropertyChanged("CelsiusLabel");
        OnPropertyChanged("Language");
      }
    }
