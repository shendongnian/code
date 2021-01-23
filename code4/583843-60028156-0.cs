    public List<Company> GetCompanies()
    {
        using (var context = new MyContext())
        {
            return context.Companies.ToList();
        }
    }
