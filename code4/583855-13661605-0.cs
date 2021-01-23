    TwitterResponse<TwitterSearchResultCollection> tr = TwitterSearch.Search("#christmas");
    
    TwitterSearchResultCollection results = tr.ResponseObject;
    List<TwitterSearchResult> resultList = results.ToList();
                
    foreach ( TwitterSearchResult resultRow in resultList ) {
        messages.AppendText( "\n" + resultRow.Text );
    }
