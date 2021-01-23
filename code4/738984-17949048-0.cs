    public ObservableCollection<ITab> Tabs
    {
     get { return _Tabs;}
     private set 
     {
       _Tabs = value;
        this.RaisePropertyChanged("Tabs");
      }
     }
