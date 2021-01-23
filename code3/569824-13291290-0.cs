    // GET api/Ceremony
    public IEnumerable<Ceremony> GetCeremonies(int? id)
    {
        if (id.HasValue)
        {
            Ceremony ceremony = db.Ceremonies.Find(id);
            return ceremony;
        }
        else
        {
            return db.Ceremonies.AsEnumerable();
        }
    }
