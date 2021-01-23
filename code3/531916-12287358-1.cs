    var venuesGrouped = enVenues.GroupBy(v => v.VenueName)
             .Select(group =>
                 new
                 {
                     VenueId = group.First().VenueId,
                     VenueName = group.Key,
                     VenueShowTimes = group.Select(v => new { PartyName = v.PartyName, PartyId = v.PartyId })
                 });
    string jsonresult = rSerialize.Serialize(venuesGrouped);
