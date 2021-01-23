        public IEnumerable<EventMonthlySummaryMonthly> GetLastYearEventGrid()
        {
            DateTime currentDate = DateTime.Now.AddYears(-1).AddMilliseconds(1);
            var summary = (from p in db.Events
                          where (p.StartDate > currentDate) && (p.StartDate != null)
                          let k = new
                          {
                              Month = p.StartDate.Month
                          }
                          group p by k into t
                          select new EventMonthlySummaryMonthly
                          {
                              Month = t.Key.Month,
                              EventsWhatsOn = t.Count(p => p.EventTypeId == 1),
                              EventsRegular = t.Count(p => p.EventTypeId == 2),
                              EventsExhibitions = t.Count(p => p.EventTypeId == 3),
                              EventsAll = t.Count(p => p.EventTypeId != null),
                          }).OrderByDescending(item=>item.Month);
            return summary;
        }
