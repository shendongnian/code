    var results = _dbContext.tbllog
        .GroupBy( t => new { t.Path, t.Message })
        .Select( g => new 
            {
                Total = g.Count(),
                Path = g.Key.Path,
                Message = g.Key.Message
            }).OrderBy(p => p.Total);
