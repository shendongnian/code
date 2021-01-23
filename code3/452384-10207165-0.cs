    var groupedData = from b in dt.AsEnumerable()
                      group b by b.Field<string>("TypeColor") into g
                      select new
                      {
                          Color = g.Key,
                          PriceSum = g.Sum(r => r.Field<int>("Price")),
                          FirstValue = g.First().Field<int>("Value")
                      };
    foreach (var g in groupedData)
    {
        string color = g.Color;
        Double priceSum = g.PriceSum;
        int firstValue = g.FirstValue;
    } 
