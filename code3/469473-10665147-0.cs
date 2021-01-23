    if (Details.Count < 6)
        Enumerable.Range(1, 6 - Details.Count).Select(x =>
        {
            var d = new City.Detail();
            Details.Add(d);
            return d;
        }).ToArray();
