    IEnumerable<ICD.ViewModels.HomeSearchViewModel> query =
                    ICDUnitOfWork.AlphaGroups.Find()
                                 .GroupJoin(
                                       ICDUnitOfWork.Alphas.Find()
                                                    .GroupBy(a => new 
                                                                    {
                                                                      BabyIndicator = a.Title.Contains("baby"),
                                                                      GroupID = a.AlphaGroupID
                                                                    }),
                                       a => a.AlphaGroupID,
                                       g => g.Key.GroupID,
                                       (alphaGroups, alphas) =>
                                          new ICD.ViewModels.HomeSearchViewModel()
                                            {
                                              AlphaGroups = alphaGroups,
                                              Alphas = alphaGroups.Title.Contains("baby") ?
                                                alphas.Aggregate((g1,g2) => g1.Concat(g2)).AsEnumerable() :
                                                alphas.Aggregate(
                                                (g1,g2) => g1.Key.BabyIndicator ?
                                                           g1 :
                                                           g2).AsEnumerable()
                                            })
