    return aspdb.RouteLinqs
        .Where(r => r.UserId == userId && r.RouteId == routeId)
        .Select(r => new Route(routeId)
        {
            Name = r.SourceName,
            Time = r.CreationTime ?? new DateTime(),
            TrackPoints = GetTrackPointsForRoute(routeId)
        })
        .FirstOrDefault();
