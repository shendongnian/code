        static void AsyncSearchSample(TwitterContext twitterCtx)
        {
            (from search in twitterCtx.Search
             where search.Type == SearchType.Search &&
                   search.Query == "LINQ To Twitter"
             select search)
            .MaterializedAsyncCallback(resp =>
            {
                if (resp.Status != TwitterErrorStatus.Success)
                {
                    Exception ex = resp.Error;
                    // handle error
                    throw ex;
                }
                Search srch = resp.State.First();
                Console.WriteLine("\nQuery: {0}\n", srch.SearchMetaData.Query);
                srch.Statuses.ForEach(entry =>
                    Console.WriteLine(
                        "ID: {0, -15}, Source: {1}\nContent: {2}\n",
                        entry.ID, entry.Source, entry.Text));
            });
        }
