    using System.Web.Http;
    ...
    [Route("getceremonies")]
    [HttpGet]
    // GET api/Ceremony
    public IEnumerable<Ceremony> GetCeremonies()
    {
        return db.Ceremonies.AsEnumerable();
    }
    [Route("getceremony")]
    [HttpGet]
    // GET api/Ceremony/5
    public Ceremony GetCeremony(int id)
    {
        Ceremony ceremony = db.Ceremonies.Find(id);
        return ceremony;
    }
    [Route("getfilteredceremonies")]
    [HttpGet]
    public IEnumerable<Ceremony> GetFilteredCeremonies(Search filter)
    {
        return filter.Ceremonies();
    }
