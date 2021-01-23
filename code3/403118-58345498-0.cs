	var statsModel = await _db.Messages
    .GroupBy(m => 1, (g, mm) => new
    {
    	Total = mm.Count(),
    	Approved = mm.Count(m => m.Approved),
    	Rejected = mm.Count(m => !m.Approved)
    })
    .SingleAsync();
