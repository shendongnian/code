    var groups =
        from C in _Connectors
        group C by new
            {
                Min = (int)Math.Min(C.DataPoint1Id, C.DataPoint2Id),
                Max = (int)Math.Max(C.DataPoint1Id, C.DataPoint2Id)
            }
        into cGroup
        select new
            {
                DataPoint1Id = cGroup.Key.Min,
                DataPoint2Id = cGroup.Key.Max,
                Connectors = cGroup.ToList(),
                Count = cGroup.Count()
            };
