    var initialQuery = BoughtItemDB.BoughtItems
                        .GroupBy(item => item.ItemCategory)
                        .Select(x => new CatSummary
                         { 
                             CatName = x.Key, 
                             CatAmount = x.Sum(amt => amt.ItemAmount)
                         });
