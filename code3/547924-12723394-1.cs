    var result = newItems.AsEnumerable()
                .GroupBy(r => r.Field<String>("BarcodeNumber"))
                .Select(g => new { 
                    Qty = g.Count(),
                    BarcodeNumber = g.Key,
                    DisplayName = g.First().Field<String>("DisplayName"),
                    UnitPrice = g.Sum(r => r.Field<double>("UnitPrice")),
                    TotalPrice = g.Sum(r => r.Field<double>("TotalPrice")),
                })
                .OrderByDescending(x => x.Qty);
