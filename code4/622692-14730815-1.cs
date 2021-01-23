        List<Event> eventDetails = new List<Event>();
        foreach (var item in result)
        {
            if (eventDetails.Last().Name == item.Name)
            {
               eventDetails.Last().AddYearAndYearId(item.Year, item.YearId);
            }
            else
            {
                eventDetails.Add(item);
            }
        }
