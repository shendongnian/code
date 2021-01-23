    var result = from p in fetchResults.Root.Elements("result")... //etc
    //Creating another list to contain desired results.
    List<Event> eventDetails = new List<Event>();
    //Create to store the previously looped title.
    string previousTitle = string.Empty;
    //Reference to previous event
    Event previousEvent = null;
    foreach (var item in result)
    {
        if (item.Name == previousTitle && previousEvent != null)
        {
            //Add to the previous event
            previousEvent.yearList.Add(item.Year);
            previousEvent.yearIdList.Add(item.YearId);
        }
        else
        {
            //otherwise add who item to eventDetails list.
            eventDetails.Add(item);
        }
        previousTitle = item.Name;
        previousEvent = item;
    }
