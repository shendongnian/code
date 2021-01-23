    List<VRTSystemOverview> systems = vrtSystemsBasicQuery.OrderBy(s => s.DHRNumber)
     .Select(s => new VRTSystemOverview {
       ID = s.ID,
      SystemNumber = s.SystemNumber,
      PriceBookCodes = s.ProductConfiguration
        .ProductConfigurations_PriceBook
        .Select(pb => pb.PriceBook.ProductCode)
        .Aggregate("", (s1, a) => s1 + "|" + a)
     })
    .ToList();
