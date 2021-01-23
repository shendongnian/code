    var res = collection.AsQueryable()
                .Where(p => p.UserID == UserID)
                .OrderByDescending(p=> p.DateCreated)
                .Take(10)
                .AsEnumerable()
                .Select(p => new MyClass
                {                          
                     Date = p.DateCreated.ToString(),
                     Status = p.Status.ToFrendlyString(),                        
                })
                .ToList();
