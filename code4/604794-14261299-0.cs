    IQueryable<Company> query = p.Companies;
    if (condition1)
    {
        query = query.Where(expression1);
    }
    
    if (condition2)
    {
        query = query.Where(expression2);
    }
