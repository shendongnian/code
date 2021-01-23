    detailsList =
            (from d in data                    // <-- The first query
             // ...
             select new Content.Grid
             {
                 // ...
             })
             .OrderBy(item => item.Order)    // <-- The calls from the second query
             .ThenBy(item => item.Title)
             .Select((t, index) => new Content.Grid()
             {
                 //...
             }).ToList();
