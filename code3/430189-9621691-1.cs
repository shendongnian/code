    foreach(var pair in actualPositions.CrossJoin(projections))
    {
        var position = Create(book, pair.Item1, pair.Item2);
        position.TargetNett = pair.Item2.DailyProjectedNet.ToString();
        yield return position;
    }
    // OR
    return actionPositions.CrossJoin(projections, (actual, project) => { /*Code in foreach loop above here, without the "yield". */ });
