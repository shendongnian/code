    public Benutzer GetUser(string Domain, string Benutzer, string Werk, string GUID)
    {
        Benutzer result = new Benutzer();
        DirectoryEntry Entry = new DirectoryEntry("LDAP://<GUID=" + GUID + ">");
        string filter = "(&(objectClass=user)(objectCategory=person)(cn=*))";
    
        DirectorySearcher Searcher = new DirectorySearcher(Entry, filter);
        SearchResult res = Searcher.FindOne();
        result =new Benutzer()
        {
            Benutzername = GetProperty(res, "sAMAccountName"),
            Vorname = GetProperty(res, "givenName"),
            Nachname = GetProperty(res, "sn"),
            eMail = GetProperty(res, "mail"),
            Unternehmen = GetProperty(res, "company"),
            Abteilung = GetProperty(res, "Department"),
            Raum = GetProperty(res, "physicalDeliveryOfficeName"),
            Beschreibung = GetProperty(res, "Description"),
            Kostenstelle = GetProperty(res, "extensionAttribute3"),
            Telefonnummer = GetProperty(res, "telephoneNumber"),
            Mobilnummer = GetProperty(res, "mobile"),
            Haustelefon = GetProperty(res, "homePhone"),
            Fax = GetProperty(res, "facsimileTelephoneNumber"),
            Pager = GetProperty(res, "pager"),
            Standort = GetProperty(res, "l")
        };              
    
        return result;  
    }
