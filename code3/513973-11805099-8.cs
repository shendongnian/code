    var statistics = (
      from record in startTimes
      group record by record.startTime
      into g
      select g;
      ).AsEnumerable().Select(
        g => new e_activeSession
        {
          workerId = wcopy,
          startTime = g.Key.GetValueOrDefault(),
          totalTasks = g.Count(),
          totalTime = g.Max(o => o.record.timeInSession).GetValueOrDefault(),
          /* ... */
         });
