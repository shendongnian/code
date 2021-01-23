    var allHeights = MyCities.SelectMany(city => 
        city.Houses.SelectMany(h => 
            h.Storeys.Values.Select(s => new { City = city, House = h, Storey = s })))
       .GroupBy(g => g.Storey.Height)
       .OrderBy(heightGroup => heightGroup.Key)
       .ToList();
    int i = 0;
    foreach (var heightGroup in allHeights)
    {
        if (i > 1)
        {
            var previousHeightGroup = allHeights[i-1].ToList();
            var previousPartIDs = previousHeightGroup.Select(g => g?.City?.Name).ToList();
            //.... <do stuff in case of i > 0>
        }
        // do other stuff
        i++;
    }
