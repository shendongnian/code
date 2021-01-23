    // All within SearchResultsAdapter.cs
    public class SearchResultsAdapter : BaseAdapter<SearchResult>
    {
    .
    .
        // Constructor
        public SearchResultsAdapter (Activity oContext)
            : base ()
        {
            // Add handler for list refresh
            ViewModel.SearchResultsUpdated += NotifyDataSetChanged;
            //
            m_oContext = oContext;
        }
    }
