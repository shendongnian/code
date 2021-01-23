    var result = A.Concat(B)
           .GroupBy(x => x.Id)
           .Select(g => new { 
                id = g.Key,
                isShipCollected = g.Any(m => m.IsChipCollected == 1),
                isShirtCollected = g.Any(m => m.IsShirtCollected == 1),
                isPackCollected = g.Any(m => m.IsPackCollected == 1)
            });
