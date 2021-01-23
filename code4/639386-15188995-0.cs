                using (var db = new Compleate())
            {
               rpBooks.DataSource = (from c in db.Categories
                                  join p in db.Products on c.ID equals p.id
                                  where c.Products.Name == "Books"
                                  select new
                                  {
                                      c.Name
                                  }).ToList();
            }
