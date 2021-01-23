    var searchResults = members.getAllMembers()...;
    if (!String.IsNullOrEmpty(search.name))
    {
        searchResults = searchResults.Where(...);
    }
    listMembers.DataSource = searchResults;
