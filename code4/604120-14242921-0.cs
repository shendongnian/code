    using (var context = new NorthwindContext()) 
    {
        var query = context.Destinations.Where(i => i.Id >= 1).Select(i => new {
                    id = i.Id,
                  name = i.Destination
        }).ToArray();
     }
