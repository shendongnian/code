    private DateTime _Date;
    public DateTime Date
    {
       get { return _Date; }
       set 
       { 
          if (value != _Date)
          {
             _Date = value;
             RaisePropertyChanged(() => Date);
          }
       }
    } 
