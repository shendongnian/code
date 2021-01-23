    public CampaignCreative GetCampaignCreativeById(int id, string[] includes)
    {
        using (var db = GetContext())
        {
            var query = db.CampaignCreatives.AsQueryable();
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            
            return query
                .AsNoTracking()
                .Where(x => x.Id.Equals(id))
                .FirstOrDefault();                    
        }
    }
