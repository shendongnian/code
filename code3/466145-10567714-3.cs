    var query= _service.GetQuery
                        .Where(data => data.SomeFlag == true);
    
    ViewBag.Total = query.Count();
    var model = query.Skip((page > 0 ? page - 1 : 0) * rows).Take(rows)
                        .AsEnumerable()
                        .Select(data => new { Foo = CalculateFoo(data.Bar); });
