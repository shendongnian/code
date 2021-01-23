    public static IQueryable GetProcessesForAllItems()
    {
        var ctx = new CS3Entities();
        var allprocesses = (from pi in ctx.ProcessesItems
                            orderby pi.SequenceNumber descending
                            select new
                                       {
                                           pi.ItemID,
                                           pi.ProcessID,
                                           pi.SequenceNumber
                                       });
        var query = allprocesses
            .GroupBy(c => c.ItemID)
            .Select(g => new
                             {
                                 ItemId = g.Key,
                                 Seq100 = g.FirstOrDefault(c => c.SequenceNumber == 100).ProcessID,
                                 Seq200 = g.FirstOrDefault(c => c.SequenceNumber == 200).ProcessID,
                                 Seq300 = g.FirstOrDefault(c => c.SequenceNumber == 300).ProcessID,
                                 Seq400 = g.FirstOrDefault(c => c.SequenceNumber == 400).ProcessID,
                                 Seq500 = g.FirstOrDefault(c => c.SequenceNumber == 500).ProcessID,
                                 Seq600 = g.FirstOrDefault(c => c.SequenceNumber == 600).ProcessID,
                                 Seq700 = g.FirstOrDefault(c => c.SequenceNumber == 700).ProcessID,
                                 Seq800 = g.FirstOrDefault(c => c.SequenceNumber == 800).ProcessID,
                                 Seq900 = g.FirstOrDefault(c => c.SequenceNumber == 900).ProcessID,
                                 //etc
                             });
        return query;
    }
