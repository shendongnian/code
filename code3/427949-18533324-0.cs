    // GET api/SitesAPI/Disposition/1
    [ActionName("Disposition")]
    [HttpGet]
    public Site Disposition(int disposition)
    {
        Site site = db.Sites.Where(s => s.Disposition == disposition).First();
        return site;
    }
