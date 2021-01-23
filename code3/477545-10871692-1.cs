    var models = db.Model.Where(f => bar.Contains(f.Id)).ToList();
    TryUpdateModel(models);
    if(ModelState.IsValid)
    {
        foreach(var model in models)
        {
            model.updated = true;
            db.Entry(model).State = EntityState.Modified;
        }
        db.SaveChanges();
    }
