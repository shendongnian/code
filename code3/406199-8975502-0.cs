    SearchResult user = null;
    using( var rootDE = new DirectoryEntry(LDAPPath, User, Password))
    {
        using( var searcher = new DirectorySearcher(rootDE))
        {
            searcher.Filter = string.Format("(&(prop1={0})(prop2={1}))", prop1Value, prop2Value);
            var user = searcher.FindOne().GetDirectoryEntry();
        }
    }
    return user;
