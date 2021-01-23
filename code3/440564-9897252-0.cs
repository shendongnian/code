    var r = a.GroupBy(e => e.cvAnoFicFin).Select(g => new
    {
        Year = g.Key,
        Jan = g.Where(e => e.cvMesFicFin == 1)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault(),
        Feb = g.Where(e => e.cvMesFicFin == 2)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault(),
        Mar = g.Where(e => e.cvMesFicFin == 3)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault(),
        Apr = g.Where(e => e.cvMesFicFin == 4)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault(),
        May = g.Where(e => e.cvMesFicFin == 5)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault(),
        Jun = g.Where(e => e.cvMesFicFin == 6)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault(),
        Jul = g.Where(e => e.cvMesFicFin == 7)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault(),
        Aug = g.Where(e => e.cvMesFicFin == 8)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault(),
        Sep = g.Where(e => e.cvMesFicFin == 9)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault(),
        Oct = g.Where(e => e.cvMesFicFin == 10)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault(),
        Nov = g.Where(e => e.cvMesFicFin == 11)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault(),
        Dec = g.Where(e => e.cvMesFicFin == 12)
               .Select(c => (int?)c.cvVlrBasFicFin).SingleOrDefault()
    });
