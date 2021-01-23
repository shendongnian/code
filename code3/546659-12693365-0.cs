    private void OnSuggestionsRequested(SearchPane sender, SearchPaneSuggestionsRequestedEventArgs args)
    {
        string query = args.QueryText;
        string[] terms = { "an item", "Oscillator", "crossbeam", "treddle", "Interossitor", "Spline", "Flange" };
        foreach (var term in terms)
        {
            if (term.StartsWith(query, StringComparison.CurrentCultureIgnoreCase))
            {
                args.Request.SearchSuggestionCollection.AppendQuerySuggestion(term);
            }
        }
    }
