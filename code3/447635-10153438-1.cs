    public void LogIn
    {
      //Load Contact List for User - Do other stuff
      foreach(Contact c in Contacts)
        c.PropertyChanged += new PropertyChangedEventHandler(ContactPropertyChanged);
    }
