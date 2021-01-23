    public ActionResult Update(EditModel model)
    {
        var entity = _session.Get<Entity>(model.Id);
        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.SomeField = model.SomeField;
        _session.SaveOrUpdate(entity);
    }
