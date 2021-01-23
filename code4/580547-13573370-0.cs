    var bbb = categories.Join(categoryLinks, c => c.CategoryID, cl => cl.CategoryId, (c, cl) => new {c, cl})
                        .GroupBy(g => g.c)
                        .Select(g => new
                                     {
                                        CategoryID = g.Key.CategoryId,
                                        CategoryDescription = g.Key.CategoryDescription,
                                        CategoryType = g.Key.CategoryType,
                                        Category = g.Key.Category1,
                                        categoryCount = g.Count()
                                     });
