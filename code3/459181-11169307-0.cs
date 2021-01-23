    using (var session = new DatabaseSession())
    {
        video2 = session.Context.Set<Video>().Include(v => v.Coworkers)
            .Single(v => v.Id == video2Id);
        coworkerA = new Coworker { Id = coworkerAId };
        session.Context.Set<Coworker>().Attach(coworkerA);
        video2.Coworkers.Clear();
        video2.Coworkers.Add(coworkerA)
        session.Context.SaveChanges();
    }
