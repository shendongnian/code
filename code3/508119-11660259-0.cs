      public string MyText 
      {
        get { return _MyText; }
        set 
        {
           _MyText = value;
           RaisePropertyChanged("MyText")
           // THen call that method
           MyMehtod();
        }
       }
