        List<Event> eventDetails = new List<Event>();
        foreach (var item in result)
        {
            Event earlierEvent = eventDetails.SingleOrDefault(ev => ev.Name == item.Name)
            
            if (earlierEvent != null)
            {
               earlierEvent.AddYearAndYearId(item.Year, item.YearId);
            }
            else
            {
                eventDetails.Add(item);
            }
        }
