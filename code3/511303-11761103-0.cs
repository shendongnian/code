    Outlook.Selection selection = Globals.ThisAddIn.Application.ActiveExplorer().Selection;
    if (selection.OfType<Outlook.ContactItem>().Count() == 1) // only support single item selection
    {
      Outlook.ContactItem contact = selection.OfType<Outlook.ContactItem>().FirstOrDefault();
      string name = contact.FullName;
      string company = contact.CompanyName;
      string address = contact.BusinessAddress;
    }
