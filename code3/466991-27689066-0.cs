    FeedQuery nextQuery = new FeedQuery();
    nextQuery.Uri = new Uri(String.Format("{0}", blogCred.feedUri));
    DateTime dateToFind = entry.Published.AddSeconds(1);
    int numberOfDates = (int)(DateTime.Now - dateToFind).TotalDays;
    nextQuery.MinPublication = dateToFind;
    nextQuery.NumberToRetrieve = 1;
    AtomFeed nextFeed = null;
    AtomEntry nextEntry = null;
    for (int i = 0; i < numberOfDates; )
    {
        nextQuery.MaxPublication = dateToFind.AddDays(i);
        nextFeed = googleService.Query(nextQuery);
        if (nextFeed.TotalResults >= 1)
        {
            nextEntry = nextFeed.Entries.FirstOrDefault();
            break;
        }
        i = i + 10;
    }
