    List<Catalogue> data = context.Catalogue
                                  .Where(x=>x.ManID == id)
                                  .GroupBy(x=> new { x.ColumnA, 
                                                     x.ColumnB, 
                                                     x.ColumnD })
                                  .Select(g => g.First())
                                  .ToList();
