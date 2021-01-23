    public class SearchViewModel : INotifyPropertyChanged
    {
        public async Task Search(string searchPhrase)
        {
            IsBusy = true;
            var results = await DoDatabaseSearch(searchPhrase);
            // do stuff with results
            IsBusy = false;
        }
        public async Task<IEnumerable<SearchResult>> DoDatabaseSearch(string searchPhrase)
        {
            // This is where you would do your search
        }
    }
