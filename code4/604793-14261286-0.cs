    IQueryable<Company> query = p.Companies.AsQueryable();
    
    if(!string.IsNullOrEmpty(variable1))
        query = query.Where(company => company.Name != "" || company.Name.Contains(variable1));
    
    if(!string.IsNullOrEmpty(variable2))
        query = query.Where(company => company.Description != "" || company.Description .Contains(variable1));
    
    bool result = query.Any();
