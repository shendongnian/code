    public class NameFinder
    {
        private string _search;
        public NameFinder(string search) {
            _search = search;
        }
        public bool Match(string item) {
            // C# equivalent of "return item LIKE _search"
        }
    }
    // Usage
    var nameFinder = new NameFinder(Search);
    List.Where(nameFinder.Match);
