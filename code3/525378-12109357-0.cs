    var favorites = (from ProductFavorite pf in allFavorites
                                 group pf by pf.ProductUid into distinctFavorites
                                 select new ProductFavorite()
                    {
                        Uid = Guid.NewGuid(),
                        ProductUid = distinctFavorites.Key,                    
                        IsFavorite = distinctFavorites.Any(p => p.IsFavorite == true),
                        IsLastUsed = distinctFavorites.Any(p => p.IsLastUsed == true),
                        LastUsedYear = distinctFavorites.Max(l => l.LastUsedYear) 
                    });
