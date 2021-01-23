    foreach (var item in Ids) {
        var page = Mapper.Map<Pages>(model);
        .
        .
        .
        .
        db.Pages.Add(page);
    }
    db.SaveChanges();
