    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Contacts cons = new Contacts();
    
      //Identify the method that runs after the asynchronous search completes.
      cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);
    
      //Start the asynchronous search.
      cons.SearchAsync(String.Empty, FilterKind.None, "Contacts Test #1");
    }
    
    void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
    {
      var myMobilePhoneContacts = new List<Contact>();
   
      foreach (var contact in e.Results)
      {
        myMobilePhoneContacts.AddRange((from phoneNumber in contact.PhoneNumbers
    				where phoneNumber.Kind == PhoneNumberKind.Mobile
     			select contact).Select(cont => (Contact)cont));
      }
    
      // do something with the contacts in myMobilePhoneContacts
    }
