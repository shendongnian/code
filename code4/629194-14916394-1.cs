    public IQueryable<Company> GetCompanies([QueryString("sportTypeID")] int? sportTypeID)
    {
        var db = new MyDatabaseContext();
        IQueryable<Company>query = db.Companies;
        if (sportTypeID.HasValue && sportTypeID>0)
        {
            return query.Join(db.SportTypes, o => o.SportTypeID, i => i.SportTypeID, (o, i) => new {
                            Company = o,
                            HasSportType = i.SportTypeID == sportTypeID
                        })
                        .Where(x => x.HasSportType)
                        .Select(x => x.Company)
                        .Distinct();
        }
        return query;
    }
