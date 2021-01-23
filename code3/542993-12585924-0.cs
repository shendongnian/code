    var query = 
        from c in 
        this.ObjectContext.People.
            Include("Careers").
            Include("Careers.Titles").
            Include("Careers.Titles.Salaries")
        where c.Careers.Any(c => c.IsActive);
    
    return query;
