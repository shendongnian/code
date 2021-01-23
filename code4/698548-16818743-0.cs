        string _contactEmailString;
        public string ContactEmailsString 
        {
          get{
              return _contactEmailString;
             }
          set
          {
             value=_contactEmailString;
             NotifyPropertyChanged("ContactEmailString");
          }
       }
