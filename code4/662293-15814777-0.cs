    ctx.E.Select(e => new {
                     E = e
                   , Ds = e.Ds
                   , numAs = e.Ds.SelectMany(d => d.Cs).SelectMany(c => c.As).Count()
                     }
                 )
         .OrderBy(e => e.numAs);
