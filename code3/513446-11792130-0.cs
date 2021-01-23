    int maxLoops = 50;
    int loopNum = 0;
    while (loopNum < maxLoops)
    {
            var list = db.Commets.Where(rec => rec.Id > Id).Select(rec => new { Id = rec.Id, Str = rec.Str }).ToList();
    
            if (list.Count > 0)
                return list;
    
            Thread.Sleep(250); //Wait 1/4 of a second
            loopNum++;
    }
