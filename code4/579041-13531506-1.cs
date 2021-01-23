    private bool _achived;
    public bool Achived
    {
       get
       {
          return _achived;
       }
       set
       {
          _achived = value;
          PropertyChanged("Achived");
       }
    }
