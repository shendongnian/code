	var results = 
		from c in Cycles
		group c by new { c.PartNo, c.Group } into g
		let c = g.Where(s => s.Start.HasValue && !s.Finish.HasValue)
		         .Select(s => s.StepNo)
		let r = g.Where(s => s.Status == "R")
		         .Select(s => s.StepNo)
		where r.Any() && c.Any()
		select new 
		{ 
		    g.Key, 
		    Steps = g.Where(s => s.StepNo <= c.Max() && s.StepNo >= r.Min()) 
		};
