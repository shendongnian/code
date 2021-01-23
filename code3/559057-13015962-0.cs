    English.Select(t => new Tuple<Thing,int>(t, 1)).Concatenate(
        German.Select(t => new Tuple<Thing,int>(t, 2)).Concatenate(
            Spanish.Select(t => new Tuple<Thing,int>(t, 3))
        )
    ).GroupBy(p => p.Item1.ID)
    .Select(g => new {
        Id = g.Key
    ,   English = g.Where(t => t.Item2==1).Select(t => t.Item2.Stuff).SingleOrDefault()
    ,   German = g.Where(t => t.Item2==2).Select(t => t.Item2.Stuff).SingleOrDefault()
    ,   Spanish = g.Where(t => t.Item2==3).Select(t => t.Item2.Stuff).SingleOrDefault()
    });
