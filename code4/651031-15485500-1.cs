    var result = records
        .SelectMany(r => new[] { r,
            new Record { SellerID = r.BuyerID, BuyerID = r.SellerID, 
                         Assets = r.Assets.Select(a => new Asset { AssetID = a.AssetID, Amount = -a.Amount}).ToList() }})
        .GroupBy(r => new { r.SellerID, r.BuyerID }) // 2
        .Select(g => new { // 3
                        Seller = g.Key.SellerID,
                        Buyer = g.Key.BuyerID,
                        Assets = g.SelectMany(r => r.Assets)
                                .GroupBy(a => a.AssetID)
                                .Select(ag => new { 
                                     AssetID = ag.Key,
                                     Amount = ag.Sum(a => a.Amount) })
                                .Where(x => x.Amount > 0)
                                .ToList() });
