    searchResults.DataSource = from r in response.Results
                               select new
                               {
                                   Title = r[SearchContentProperty.Title],
                                   Summary = r[SearchContentProperty.HighlightedSummary],
                                   Id = r[SearchContentProperty.Id] * 10,
                                   Quicklink = r[SearchContentProperty.QuickLink],
                                   Description = r[SearchContentProperty.Description].ToString().Split(' ').Take(300).Aggregate((a, b) => a + " " + b);
                               };
