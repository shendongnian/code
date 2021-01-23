    public static class AddressBookManager
    {
      #region Singleton
      static readonly AddressBookManager instance = new AddressBookManager();
      private AddressBookManager(); // prevent creating instances of this
      public static AddressBookManager Current { get { return instance; } }
      #endregion
      AddressBook master = new AddressBook(); // the master address book
      public AddressBook Master
      { 
        get { return master; }  // get the master address book
        set { master = value; } // set the master address book
      }
    }
