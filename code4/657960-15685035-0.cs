    // This would put all failures at the top of the list
    All = All.OrderBy(s => {
        try { return int.Parse(s.Split('|')[1]); }
        catch { return 0; }
    }).ToList();
