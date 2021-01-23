    var ys = context.X
                    .Where(x => x.date > DateTime.Now)
                    .Select(x => new Y { Name = x.Name });
    c.Ys.InsertAllOnSubmit(ys);
                      
