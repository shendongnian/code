      public override int SaveChanges()
      {
         if( ChangeTracker.Entries().Any( e => e.State != EntityState.Unchanged ) )
         {
            //insert the entry into the History table
         }
         return base.SaveChanges();
      }
