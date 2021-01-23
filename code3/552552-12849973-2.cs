    var smallestBeamForTypes = 
        from strongBeam in db.Values
        where strongBeam.Ix >= iRequired
        group strongBeam by beam.ElementType into beamTypeGroups
        from group in beamTypeGroups
        let minIx = group.Min(beam => beam.Ix)
        select new {
            ElementType = group.Key,
            SmallestBeam = group.First(beam => beam.Ix == minIx)
        };
