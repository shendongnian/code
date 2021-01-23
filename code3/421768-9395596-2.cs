        static IEnumerable<Article> GetArticles(List<Article> articles, int articlesToRetrieve, int startingID)
        {
            IEnumerable<Article> results = null;
            results = articles.OrderByDescending(a => a.Rating).ThenBy(a => a.ID);
            if (startingID > 0)
            {
                int lastRating = articles.Single(aa => aa.ID == startingID).Rating;
                results = results.Where(a => a.Rating < lastRating || (a.Rating == lastRating && a.ID > startingID));
            }
            if (articlesToRetrieve > 0)
            {
                results = results.Take(articlesToRetrieve);
            }
            return results;
        }
