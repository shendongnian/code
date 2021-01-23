    var categories = from i in (from c in _db.Categories
                                select new
                                {
                                    ID = c.ID,
                                    Name = c.Name,
                                    ItemCount = c.Items.Count
                                }).ToList()
                     select new
                     {
                         ID = i.ID,
                         Name = i.Name,
                         ItemCount = i.ItemCount,
                         Breadcrumbs = Infrastructure.CategoryHelpers.Breadcrumbs(c.ID, -1, String.Empty)
                     };
