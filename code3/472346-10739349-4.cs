    var mobileList = listOfAllMobiles
        .Select(m => new Mobile
                     {
                         IsApproved = m.IsApproved == true && !listOfAllMobiles
                             .Any(l => l.ModelID == m.ModelID
                                 && l.ManufacturerID == m.ManufacturerID
                                 && l.MobileID != m.MobileID),
                         MobileID = m.MobileID,
                         ModelID = m.ModelID,
                         ManufacturerID = m.ManufacturerID
                     })
        .ToList();
