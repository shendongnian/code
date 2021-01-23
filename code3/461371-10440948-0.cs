    static void RunPairs(IEnumerable<Pair> pairs, Action<double> pairEvent)
    {
      if (pairs == null || !pairs.Any() || pairEvent == null)
        return;
      var sorted = pairs.OrderBy(p => p.Timestamp);
      var first = sorted.First().Timestamp;
      var wrapped = pairs.Select(p => new { Offset = (p.Timestamp - first), Pair = p });
    
      var start = DateTime.Now;
    
      double interval = 250; // 1/4 second
      Timer timer = new Timer(interval);
    
      timer.AutoReset = true;
      timer.Elapsed += (sender, elapsedArgs) =>
      {
        var signalTime = elapsedArgs.SignalTime;
        var elapsedTime = (signalTime - start);
    
        var pairsToTrigger = wrapped.TakeWhile(wrap => elapsedTime > wrap.Offset).Select(w => w.Pair);
        wrapped = wrapped.Skip(pairsToTrigger.Count());
    
        foreach (var pair in pairsToTrigger)
          pairEvent(pair.Value);
    
        if (!wrapped.Any())
          timer.Stop();
      };
      timer.Start();
    }
