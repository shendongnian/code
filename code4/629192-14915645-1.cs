    public IQueryable<Company> GetCompanies([QueryString("sportTypeID")] int sportTypeID)
    {
        var db = new MyDatabaseContext();
        IQueryable<Company>query = db.Companies;
        if (sportTypeID.HasValue && sportTypeID>0)
        {
            query = query.Where(theCompany => theCompany.sportTypes.Any(stype => stype.SportTypeID == sportTypeID)));
        }
        return query;
    }
