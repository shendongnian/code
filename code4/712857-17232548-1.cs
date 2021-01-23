    IQueryable<Person> query = db.persons;
    query = query.Where(c => c.Name == model.Name);
    query = query.Where(c => c.CustomerBonusPoint.BonusPoints == model.BonusPoints);
    query = query.Where(c => c.CustomerSaleFigures.Sum(sf => sf.Turnover) > model.Turnover);
    return query.ToList();
