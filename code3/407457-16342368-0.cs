    using DotRas;
    string path = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
    RasPhoneBook pbk = new RasPhoneBook();
    pbk.Open(path);
    
    foreach (RasEntry entry in pbk.Entries)
    {
      MessageBox.Show(entry.Name);
    }
