    var merged = Rectagles.Select(r => new { 
            r.Id, 
            r.Type, 
            r.Bounds,
            Radius = float.NaN,
            Centre = default(Coordinates) })
        .Concat(Circles.Select(c => new {
            c.Id, 
            c.Type, 
            c.Bounds,
            c.Radius,
            c.Centre }));
