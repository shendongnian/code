    return aspdb.RouteLinqs
        .Where(r => r.UserId == userId && r.RouteId==routeId)
        .Select(r => new Route(routeId)
        {
            Name = first.SourceName,
            Time = first.CreationTime ?? new DateTime(),
            TrackPoints = GetTrackPointsForRoute(routeId)
        })
        .FirstOrDefault();
