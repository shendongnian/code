    var result = records
        .SelectMany(r => new[] { 
            new Record { SellerID = r.SellerID, BuyerID = r.BuyerID, 
                         Assets = r.Assets },
            new Record { SellerID = r.BuyerID, BuyerID = r.SellerID, 
                         Assets = r.Assets.Select(a => new Asset { AssetID = a.AssetID, Amount = -a.Amount}).ToList() }})
        .GroupBy(r => new { r.SellerID, r.BuyerID })
        .Select(g => new {
                        Seller = g.Key.SellerID,
                        Buyer = g.Key.BuyerID,
                        Assets = g.SelectMany(r => r.Assets)
                                .GroupBy(a => a.AssetID)
                                .Select(ag => new { 
                                     AssetID = ag.Key,
                                     Amount = ag.Sum(a => a.Amount) })
                                .Where(x => x.Amount > 0)
                                .ToList() });
