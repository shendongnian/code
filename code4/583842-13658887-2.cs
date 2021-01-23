    public IQueryable<Company> GetCompanies()
    {
        using(var context = new MyContext()){ 
            return context.Companies;
        }
    }
