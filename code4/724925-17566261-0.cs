    public class SearchResults
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public SearchResults(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public override string ToString()
        {
            return String.Format("{0} {1}", Name, Surname);
        }
    }
    ...
    [WebMethod] 
    Public static List<string> QuerySearch()
    {
        ...
        return lsSearchResults.Select(i => i.ToString());
    }
