    var Cities = 
               (from c in db.Cities
               orderby c.Name
               select new
               {
                   Name = c.Name,
                   Houses = c.Houses.OrderBy(c => c.Number).ToList()
               }
              );
