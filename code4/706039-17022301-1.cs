    enum SearchControls
    {
        None = 0,
        Search = 1,
        Replace = 1 << 2,
        RecentSearches= 1 << 3,
    }
    class SearchForm
    {
        public void SearchForm(SearchControls searchControls)
        {
            if(searchControls.HasFlag(SearchControls.Search))
                CreateAndAddSearchControl();   
            if(searchControls.HasFlag(SearchControls.Replace))
                CreateAndAddReplaceControl();
            if(searchControls.HasFlag(SearchControls.RecentSearches))
                CreateAndAddRecentSearchesControl();
        }    
    }
