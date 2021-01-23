        _twitterService = (App.Current as App).Twitter;
        var searchOptions = new SearchOptions { Q = _hashTag.Name, IncludeEntities = false, Resulttype = _twitterSearchResultType };
        if (_returnedResultsCount != null)
            searchOptions.Count = _returnedResultsCount;
        _twitterService.Search(searchOptions, (twitterSearchResult, twitterSearchResponse) =>
        {
            try
            {
                if (twitterSearchResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<TwitterStatus>));
                        ser.WriteObject(ms, twitterSearchResult.Statuses);
                        byte[] data = ms.ToArray();
                        result(new LoadRequestResult(new MemoryStream(data)));
                    }
                }
                else
                {
                    result(new LoadRequestResult(new MemoryStream()));
                }
            }
            catch
            {
                result(new LoadRequestResult(new MemoryStream()));
            }
        });
    
