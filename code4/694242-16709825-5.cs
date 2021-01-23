    private static DateInRange(
        DateTime sendDate,
        DateTime bouncedDate,
        int deliveredCalcDelayDays)
    {
        if (sentDate < bouncedDate)
        {
            return false;
        }
        return sentDate < bouncedDate.AddDays(deliveredCalcDelayDays);
    }
    static IEnumerable<event_data> GetDeliveredMails(
               IEnumerable<event_data> sent,
               IEnumerable<event_data> bounced,
               int siteId,
               int mlId,
               int mId,
               int deliveredCalcDelayDays)
    {
        var grouped = bounced.GroupBy(
            b => b.email.ToLowerInvariant());
        var lookup = grouped.ToDictionary(
            g => g.Key,
            g => g.OrderBy(e => e.event_date).Select(
                e => new Func<DateTime, bool>(
                    s => DateInRange(s, e.event_date, deliveredCalcDelayDays))).ToList());
        foreach (var s in sent)
        {
            var key = s.email.ToLowerInvariant();
            List<Func<DateTime, nool>> checks;
            if (lookup.TryGetValue(key, out checks))
            {
                var match = checks.FirstOrDefault(c => c(s.event_date));
                if (match != null)
                {
                    checks.Remove(match);
                    continue;
                }
            }
            yield return new event_data
                {
                    .sid = siteid;
                    .mlid = mlid;
                    .mid = mid;
                    .email = s.email;
                    .event_date = s.event_date;
                    .event_status = "Delivered";
                    .event_type = "Delivered";
                    .id = s.id;
                    .number = s.number;
                    .laststoretransaction = s.laststoretransaction
                };
        }
    }
