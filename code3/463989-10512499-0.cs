    public class TwitterViewModel
        : MvxViewModel
        , IMvxServiceConsumer<ITwitterSearchProvider>
    {
        public TwitterViewModel(string searchTerm)
        {
            StartSearch(searchTerm);
        }
        private ITwitterSearchProvider TwitterSearchProvider
        {
            get { return this.GetService<ITwitterSearchProvider>(); }
        }
        private void StartSearch(string searchTerm)
        {
            if (IsSearching)
                return;
            IsSearching = true;
            TwitterSearchProvider.StartAsyncSearch(searchTerm, Success, Error);
        }
        // ...
    }
