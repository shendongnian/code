    private void GetGroupEmail() {
        using (var searcher = new DirectorySearcher()) {
            searcher.Filter = "(&(objectClass=group))";
            searcher.SearchRoot = entry;
            searcher.PropertiesToLoad.Add("mail");
            foreach (SearchResult sr in searcher.FindAll()) {
                var email = GetSearchResultProperty(sr, "mail");
            }
        }
    }
    private string GetSearchResultProperty(SearchResult sr, string propertyName) {
        var property = sr.Properties[propertyName];
        if (property != null && property.Count > 0) {
            return (string)property[0];
        } else {
            return null;
        }
    }
