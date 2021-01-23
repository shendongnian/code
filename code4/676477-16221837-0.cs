    private IObservable<List<string>> Search(string searchTerm)
    {
        return Observable.Create<List<string>>(o =>
        {
            var searchClient = new SearchServiceClient();
            var s = Observable
                .FromEventPattern<SearchCompletedEventArgs>(searchClient, "SearchCompleted");
            var subscription = s.Subscribe(
                r =>
                {
                    if (r.EventArgs.Error == null)
					{
                        o.OnNext(r.EventArgs.Result);
						o.OnCompleted();
                    }
					else
                    {
                        o.OnError(r.EventArgs.Error);
                    }
                });
            searchClient.SearchAsync(searchTerm);
            return subscription;
        });
    }
