    public void SearchByPlace(string city)
            {
                DirectoryEntry Entry = new DirectoryEntry("LDAP://" + Properties.Settings.Default.Domain);
                string filter = "(&(objectClass=user)(objectCategory=person)(l=" + city + ")(cn=*))";
                DirectorySearcher Searcher = new DirectorySearcher(Entry, filter);
    
                var q = from s in Searcher.FindAll().OfType<SearchResult>()
                        select new
                        {
                            Benutzer = GetProperty(s, "sAMAccountName"),
                            eMail = GetProperty(s, "mail"),
                            Vorname = GetProperty(s, "givenName"),
                            Nachname = GetProperty(s, "sn"),
                            Telefon = GetProperty(s, "telephoneNumber"),
                            UserID = s.GetDirectoryEntry().Guid
                        };
    
                this.myListView.DataSource = q;
                this.myListView.DataBind();
            }
