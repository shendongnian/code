    ProviderDB db = new ProviderDB();
                    try
                    {
                        IQueryable<dynamic> query;
                        if (StakeCategoryIdsByStakeBuyIn != null)
                        {
                            query = (from gc in db.GameCombinations.Where(x => x.CurrencyId == CurrencyId && x.GameTypeId == GameTypeId
                                                && (CategoryId == 0 || x.CategoryId == CategoryId)
                                                && (GameId == 0 || x.GameId == GameId)
                                                && (LimitVariantId == 0 || x.LimitVariantId == LimitVariantId)
                                                && StakeCategoryIdsByStakeBuyIn.Contains(x.StakeCategoryId)
                                            )
                                     join sbsc in db.StakeBuyInByStakeCategories
                                     on gc.StakeBuyInByStakeCategoryId equals sbsc.StakeBuyInByStakeCategoryId
                                     join gt in db.GameTables
                                     on gc.GameCombinationId equals gt.GameCombinationId
                                     join gx in db.Games
                                     on gc.GameId equals gx.GameId into joined
                                     from gx in joined.DefaultIfEmpty()
                                     where gt.BuyIn == sbsc.StakeBuyInId
                                     select new
                                     {
                                         GameTableId = gt.GameTableId,
                                         Description = gt.Description,
                                         BuyIn = gt.BuyIn,
                                         Table = gx.GameName,
                                         MaxAllowPlayer = gt.MaxAllowPlayer
                                     }).Distinct();
                        }
              }
