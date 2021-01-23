    var service = GetService();
    var view = new ItemView(1);
    var searchFilter = new SearchFilter.IsEqualTo(ContactSchema.EmailAddress1, "test@domain.dk");
    var contacts = service.FindItems(WellKnownFolderName.Contacts, searchFilter, view);
    var contact = contacts.ElementAt(0) as Contact;
    // Works fine.
    contact.CompanyName = "SomeCompany";
    contact.Update(ConflictResolutionMode.AlwaysOverwrite);
    // Works fine as well.
    contact.CompanyName = "";
    contact.Update(ConflictResolutionMode.AlwaysOverwrite);
