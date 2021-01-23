    List<VRTSystemOverview> systems = vrtSystemsBasicQuery.OrderBy(s => s.DHRNumber)
     .Select(s => new VRTSystemOverview {
       ID = s.ID,
       SystemNumber = s.SystemNumber,
       PriceBookCodeList = s.ProductConfiguration
        .ProductConfigurations_PriceBook
        .Select(pb => pb.PriceBook.ProductCode)
        .ToList()
     })
    .AsEnumerable()
    .Select(s => new {
        ID = s.ID,
        SystemNumber = s.SystemNumber,
        PriceBookCodes = string.Join("|", s.PriceBookCodeList)
    });
