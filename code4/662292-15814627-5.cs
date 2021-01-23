    from a in ctx.A
    group a by a.C.D.E into g
    orderby g.Count()
    select new {
        E = g.Key,
        Ds = g.Key.Ds,
        numAs = g.Count()
    }
