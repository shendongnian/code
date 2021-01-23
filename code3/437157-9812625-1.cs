    class SearchViewModel : BaseViewModel<SearchResultItem>
    {        
        private readonly IDownloaderFactory _factory;        
    
        public SearchViewModel( IDownloaderFactory factory)
            : base(model)
        {
            _factory = factory;
        }
        private void Download(object sender, DoWorkEventArgs e) 
        {
            _factory.Create().Download(item);
        }
    }
