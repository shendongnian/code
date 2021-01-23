    public CampaignCreative GetCampaignCreativeById(
        int id, 
        params Expression<Func<T, object>>[] includes
    ) {
        using (var db = GetContext()) {
            var query = db.CampaignCreatives;
            return includes
                .Aggregate(
                    query.AsQueryable(), 
                    (current, include) => current.Include(include)
                )
                .FirstOrDefault(e => e.Id == id);
        }
    }
