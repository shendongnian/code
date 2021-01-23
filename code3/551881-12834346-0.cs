    private string /*or whatever*/ retrieveList(
        string salCode, string groupKeyword, string text)
    {
        if (String.IsNullOrEmpty(salCode) ||
            String.IsNullOrEmpty(groupKeyword) ||
            String.IsNullOrEmpty(text))
        {
            return null;
        }
        ...
    }
