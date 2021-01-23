    IQueryable<Convention> query = db.Conventions;
    if (!string.IsNullOrWhiteSpace(inputCategory))
    {
        query = query.Where(p => p.Categories.Contains(inputCategory));
    }
    if (!string.InNullOrWhiteSpace(inputName))
    {
        query = query.Where(p=> p.Name == inputName);
    }
