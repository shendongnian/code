      EntityQuery<EmployeeProduct> query = from c in _employ.CountProduct()
                                             group c by new {c.UserId, c.ProductId, c.Name}
                                             into g
                                             select new {
                                                g.UserId,
                                                g.ProductId,
                                                g.Name,
                                                Count = g.Count()
                                             }
