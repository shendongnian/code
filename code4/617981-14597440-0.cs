    public Type T
    {
        get
          {
               return this.t;
          }
        set
          {
               this.t = value;
               contained.P1 = /*Some new value*/;
               this.OnPropertyChanged("T");
          }
    }
