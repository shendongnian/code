    //NOTE: This can be made static with no modifications
    public bool ActiveDirectoryAuthenticate(string username, string password)
    {
        bool result = false;
        using (DirectoryEntry _entry = new DirectoryEntry())
        {
            _entry.Username = username;
            _entry.Password = password;
            DirectorySearcher _searcher = new DirectorySearcher(_entry);
            _searcher.Filter = "(objectclass=user)";
            try
            {
                SearchResult _sr = _searcher.FindOne();
                string _name = _sr.Properties["displayname"][0].ToString();
                result = true;
            }
            catch
            { /*TODO: Handle exceptions !! */ }
        }
        return result; //true = user authenticated!
    }
