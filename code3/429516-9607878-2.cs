    var status = Observable.FromEvent<...>(LocationServices, "StatusChanged");
    var readys = status.Where(o => o.EventArgs.Status == GeoPositionStatus.Ready);
    var notReadys = status.Where(o => o.EventArgs.Status != GeoPositionStatus.Ready);
    var positions = Observable.FromEvent<...>)(LocationServices, "PositionChanged");
    var readyPositions = from r in readys
                         from p in positions.TakeUntil(notReadys)
                         select p;
    //now you can use the Poll operator
    readyPositions = readyPositions.Poll(TimeSpan.FromSeconds(5));
