    // All within ViewModel.cs
    private Action SearchResultsUpdated;
    private List<SearchResult> m_oSearchResults;
    Public List<SearchResult> SearchResults
    {
        get
        {
            if (m_oSearchResults == null)
                m_oSearchResults = new List<SearchResult> ();
            return m_oSearchResults;
        }
        set
        {
            if (value != m_oSearchResults)
            {
                m_oSearchResults = value;
                //
                // Fire update event
                if (SearchResultsUpdated != null)
                    SearchResultsUpdated ();
            }
        }
    }
