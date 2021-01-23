    from ev in db.Events
    where ev.Block.BlockID == 1
    group ev by ev.Device.Cluster.Region.ID into g
    // group ev by ev.Device.Cluster.ClusterID into g
    select new
    {
        RegionID = g.Key, // ClusterID = g.Key,
        AverageIntensity = g.Average(x => x.Intensity),
        AverageAcceleration = g.Average(x => x.Acceleration),
    };
