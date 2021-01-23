    var result = A.Concat(B)
            .GroupBy(x => x.Id)
            .Select(g => new {//or new <A and B's generic type>, then change the underCode with proper case
                 id = g.Key,
                 isShipCollected = g.Max(m => m.IsChipCollected),
                 isShirtCollected = g.Max(m => m.IsShirtCollected),
                 isPackCollected = g.Max(m => m.IsPackCollected)
        });
