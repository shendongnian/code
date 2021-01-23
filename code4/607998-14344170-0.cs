    // 'imagined' ISearchType interface
    public interface ISearchType
    {
        int Id { get; set; }
        string LastName { get; set; }
    }
    // 'imagined' TutorSearch concrete class
    public class TutorSearch : ISearchType
    {
        public int Id { get; set; }
        public string LastName { get; set; }
    }
    // your revised controller code
    private readonly ISearchType _tutorSearch;
    public SearchController(ISearchType searchType)
    {
        _tutorSearch = searchType;
    }
