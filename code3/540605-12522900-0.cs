    private void AddEntry(XElement xml, string user, string password)
    {
        xml.Add(new XElement("Entry",
                             new XElement("User", user),
                             new XElement("Password", password)));
    }
