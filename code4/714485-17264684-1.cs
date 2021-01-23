    var newList =  (from a in list1
                    join b in list2
                    on a.alias equals b.alias
                    select new
                    {
                      a.Alias,
                      a.Name,
                      a.Email,
                      b.ItemCount,
                      b.Size
                    }).ToList();
