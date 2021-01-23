    var list = MainList.Join(DetailsList, x=>x.ID, x=>x.MAINLink,(x,y)=> new {x,y})
                       .GroupBy(a=>a.x.ID)
                       .Select(g=>g.Select((k,i)=>new {k,i}))
                       .SelectMany(a=>a)
                       .Select((a)=> new {
                                         Main = a.k.x,
                                         SequentialNUM = a.i + 1,
                                         Detail = a.k.y
                                       })
                       .OrderBy(x=>x.Main.Id);
