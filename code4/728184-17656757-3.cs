    List<VRTSystemOverview> systems = vrtSystemsBasicQuery.OrderBy(s => s.DHRNumber)
     .Select(s => new VRTSystemOverview {
       ID = s.ID,
      SystemNumber = s.SystemNumber,
      PriceBookCodes = s.ProductConfiguration
        .ProductConfigurations_PriceBook
        .Select(pb => string.Join("|", pb.PriceBook.ProductCode))
     })
    .ToList();
