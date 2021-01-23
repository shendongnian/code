            var twitterCtx = new TwitterContext(...);
            var queryResults =
                from search in twitterCtx.Search
                where search.Type == SearchType.Search &&
                      search.Query == "Linq To Twitter"
                select search;
            Search srch = queryResults.Single();
            Console.WriteLine("\nQuery: {0}\n", srch.QueryResult);
            srch.Statuses.ForEach(entry =>
                Console.WriteLine(
                    "ID: {0, -15}, Source: {1}\nContent: {2}\n",
                    entry.StatusID, entry.Source, entry.Text));
