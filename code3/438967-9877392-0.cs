    public IEnumerable<CalendarItem> GetCalendarItems(DateTime? startDate = new DateTime?(), DateTime? endDate = new DateTime?())
    {
        if (startDate.HasValue && endDate.HasValue)
        { 
          DateTime? start = startDate.Value;
          DateTime? end = endDate.Value;
          var items = session.Linq<CalendarItem>()
                             .Where(x => x.EventDate >= start && x.EventDate <= end)
                             .ToList<CalendarItem>();
          return items; 
        }
        ...
    }
