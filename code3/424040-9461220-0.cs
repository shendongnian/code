    public interface ISearchProvider
    {
        IEnumerable<SearchResultItem> Search(string keyword);
    }
    public interface ISearchResultItem
    {
        string Title {get; }
        string Description {get; }
        NameValueCollection Metadata {get; }
    }
