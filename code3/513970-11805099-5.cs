    var statistics =
      from record in startTimes.AsEnumerable()
      group record by record.startTime
      into g
      select new e_activeSession
      {
        workerId = wcopy,
        startTime = g.Key.GetValueOrDefault(),
        totalTasks = g.Count(),
        totalTime = g.Max(o => o.record.timeInSession).GetValueOrDefault(),
        /* ... */
      };
