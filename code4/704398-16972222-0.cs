    var result = trackingList.Descendants("event")
                .Select(E => new { Value3 = E.Element("value3").Value, 
                                   Value4 = E.Element("value4").Value })
                .GroupBy(g => g.Value3)
                .Select(g => new { 
                     Value3 = g.Key, 
                     DistintValue4 = g.Select(x => x.Value4).Distinct()
                 });
