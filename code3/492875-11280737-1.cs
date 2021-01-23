    var firstRoute = aspdb.RouteLinqs
        .Where(r => r.UserId == userId && r.RouteId==routeId)
        .FirstOrDefault();
    if (firstRoute == null)
    {
        return null;
    }
    else
    {
        return new Route(routeId)
        {
            Name = first.SourceName,
            Time = first.CreationTime ?? new DateTime(),
            TrackPoints = GetTrackPointsForRoute(routeId)
        };
    }
