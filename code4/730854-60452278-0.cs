    using (var transitron = ctx.Database.BeginTransaction())
    {
      try
      {
        var employer = new Employ { Id = 1 };
        ctx.Entry(employer).State = EntityState.Deleted;
        ctx.SaveChanges();
        transitron.Commit();
      }
      catch (Exception ex)
      {
        transitron.Rollback();
        //capture exception like: entity does not exist, Id property does not exist, etc...
      }
    }
