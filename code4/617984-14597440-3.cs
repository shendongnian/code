    public Type T1
    {
        get
          {
               return this.t1;
          }
        set
          {
               this.t1 = value;
               contained.P1 = CalculateContainedValue();
               this.OnPropertyChanged("T1");
          }
    }
    public Type T2
    {
        get
          {
               return this.t2;
          }
        set
          {
               this.t2 = value;
               contained.P1 = CalculateContainedValue();
               this.OnPropertyChanged("T2");
          }
    }
    private Type CalculateContainedValue()
    {
        return /* Some combination of T1, T2, ... */ ;
    }
