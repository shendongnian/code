    var set = this.Set<T>();
    if (this.Entry(entity).State == EntityState.Detached)
    {
        var attached = set.Find(id);
        if (attached != null) { this.Entry(attached).State = EntityState.Detached; }
        this.Attach(entity);
    }
    set.Update(entity);
