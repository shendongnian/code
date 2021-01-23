    select new EventMonthlySummaryMonthly
    {
       Month = t.Key.Month,
       EventsWhatsOn = t.Count(p => p.EventTypeId == 1),
       EventsRegular = t.Count(p => p.EventTypeId == 2),
       EventsExhibitions = t.Count(p => p.EventTypeId == 3),
       EventsAll = t.Count(p => p.EventTypeId != null),
       MaxDateInMoth = t.Max(p => p.StartDate)
    }).OrderByDescending (x => x.MaxDateInMoth)
