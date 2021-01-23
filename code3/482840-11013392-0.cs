        using (var ss = NHibHelp.OpenSession())
        using (var tt = ss.BeginTransaction())
        {
          var entity = new Entity();
          var clonedEntity = entity.Clone();
          ss.Save(entity);
          ss.Save(clonedEntity);
    
          tt.Commit();
        }
