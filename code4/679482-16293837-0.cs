    var serverNames = new string[]{"ServerX", "ServerY"};
    var result = db.Processes
        .Where(p => serverNames.Contains(p.ID) && p.Type == "Complete")
        .GroupBy(p => p.ProcessTime)
        .Select(g => new
        {
            ProcessTime = g.Key,
            AmountOfProcesses = g.Count()
        })
        .OrderBy(x => x.ProcessTime);
