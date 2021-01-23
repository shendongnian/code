    inputList.GroupBy(x => new { x.Name, x.Year })
             .Select(x => new
                          {
                              ProductName = x.Key.Name,
                              OriginYear = x.Key.Year, 
                              Vendor_Count = x.ToDictionary(y => y.Vendor
                                                            y => y.Count)
                          })
             .OrderBy(x => x.ProductName).ThenBy(x => x.OriginYear);
