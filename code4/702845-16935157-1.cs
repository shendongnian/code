     public string Id
     {
          get { return _id; }
          set
          {
               _id = value;
               RaisePropertyChanged(() => Id);
          }
     }
     private DateTime _id;
