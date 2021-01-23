    ThreadPool.QueueUserWorkItem(_ =>
       {
         //avoids memory leaks with undisposed contexts...
         using(DatabaseContext context = new DatabaseContext(new EntityConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString)))
         {
             MiniProfilerEF.Initialize();
             var consistantUser = context.Set<User>().Get(user.Id);
             action(consistantUser);
             context.SaveChanges();
         }
       });
