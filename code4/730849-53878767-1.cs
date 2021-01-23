    using(Context context = new Context())
    {
         var entry = context.Entry(employ);
         if(entry.State == EntityState.Detached)
         {
            context.Employee.Attach(employ);
         }                             
                        
         context.Employee.Remove(query);
         context.SaveChanges();
         //Some stuff here
    }
