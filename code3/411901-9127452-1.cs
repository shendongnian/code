    inputList.GroupBy(x => new { x.Name, x.Year })
             .Select(x => new
                          {
                              ProductName = x.Key.Name,
                              OriginYear = x.Key.Year, 
                              Vendor_Count = x.GroupBy(y => y.Vendor)
                                              .ToDictionary(y => y.Key,
                                                            y => y.Sum(z => z.Count))
                          })
             .OrderBy(x => x.ProductName).ThenBy(x => x.OriginYear);
