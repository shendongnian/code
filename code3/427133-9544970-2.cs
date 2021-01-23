    var contacts = new List<EF4Entity>()
    if (Session["Contacts"] != null){
      contacts = Session["Contacts"] as List<EF4Entity>
    }
    
    var newContact = new EF4Entity()
    //fill your new contact here
    contacts.Add(newContact)
    
    //bind your RadPanelItems here
    
    //store it to the session
    Session["Contacts"] = contacts
