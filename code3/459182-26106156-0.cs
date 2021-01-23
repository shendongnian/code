    public Video Update(Video entity)
    {
        //Creates database context. When it disposes, it calls context.SaveChanges()
        using (var session = new DatabaseSession())
        {
            entity = session.Context.Set<Video>().Attach(entity);
            session.Context.Entry(entity).Collection(p => p.Coworkers).Load();
            session.Context.Entry(entity).State = EntityState.Modified;
        }
        return entity;
    }
