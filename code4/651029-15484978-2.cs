    var recordItemComparer = new RecordItemEqualityComparer();
    var items = groups.SelectMany(r => r.Assets.Select(a => new RecordItem {
                                                                BuyerID = r.BuyerID,
                                                                SellerID = r.SellerID,
                                                                AssetID =a.AssetID,
                                                                Amount = a.Amount
                                                            }))
                      .GroupBy(ri => ri, recordItemComparer)
                      .Select(g => new RecordItem() {
                            BuyerID = g.Key.BuyerID,
                            SellerID = g.Key.SellerID,
                            AssetID = g.Key.AssetID,
                            Amount = g.Sum(ri => (ri.BuyerID == g.Key.BuyerID) ? ri.Amount : -1 * ri.Amount)
                      }).ToList();
