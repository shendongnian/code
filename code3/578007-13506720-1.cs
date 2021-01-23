    bool hasActivePlayer = false;
    foreach (var skeleton in allSkeletons)
    {
        if (skeleton.TrackingState != SkeletonTrackingState.Tracked)
        {
            continue;
        }
        hasActivePlayer = true;
        ....
    }
    if (hasActivePlayer == false)
    {
        // you aren't tracking anyone, deal with it
    }
