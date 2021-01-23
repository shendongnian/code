    var ceremonyInDb = db.Ceremonies.Include(c => c.Menus)
        .Single(c => c.Id == ceremony.Id);
    db.Entry(ceremonyInDb).CurrentValues.SetValues(ceremony);
    foreach (var menuInDb in ceremonyInDb.Menus.ToList())
        if (!ceremony.Menus.Any(m => m.Id == menuInDb.Id))
            db.Menus.Remove(menuInDb);
    foreach (var menu in ceremony.Menus)
        if (!ceremonyInDb.Menus.Any(m => m.Id == menu.Id))
            ceremonyInDb.Menus.Add(menu);
    db.SaveChanges();
