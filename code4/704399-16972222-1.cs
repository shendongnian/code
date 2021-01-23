    var result = trackingList.Descendants("event")
                .Select(E => new { Value1 = E.Element("value1").Value,
                                   Value3 = E.Element("value3").Value, 
                                   Value4 = E.Element("value4").Value })
                .GroupBy(g => g.Value3)
                .Select(g => new { 
                     Value3 = g.Key, 
                     //DistintValue4 = g.Select(x => x.Value4).Distinct(),
                     DateIn = g.Where(x => x.Value4 == "IN").Select(x => x.Value1).FirstOrDefault(),
                     DateOut = g.Where(x => x.Value4 == "OUT").Select(x => x.Value1).FirstOrDefault()
                 });
