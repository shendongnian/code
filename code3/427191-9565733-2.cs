     PCBuilds = repository.GetProductDescriptions(setName)
                          .Where(x => x.ExternalCat.CatName == category)
                          .OrderBy(
                              x => x.BDetails
                                    .Where(c => c.IsSelected == true)
                                    .Select(c => c.Product.ListPrice)
                                    .Sum())
                          .Skip((page - 1) * pagesize)
                          .Take(pagesize)
                          .ToList()
