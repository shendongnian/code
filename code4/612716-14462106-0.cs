    var destinations = from s in sources
                       group s by new { s.A, s.B } into g
                       select new Destination()
                       {
                           A = g.Key.A,
                           B = g.Key.B,
                           Cs = g.Select(x => x.C).ToList()
                       };
