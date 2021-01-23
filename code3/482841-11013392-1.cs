    var entity = new Entity();
    using (var ss = NHibHelp.OpenSession())
    using (var tt = ss.BeginTransaction())
    {      
         ss.Save(entity);
         tt.Commit();
    }
    using (var ss = NHibHelp.OpenSession())
    using (var tt = ss.BeginTransaction())
    {      
         ss.Save(entity);
         tt.Commit();
    }
