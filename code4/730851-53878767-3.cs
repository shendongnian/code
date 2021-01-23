    using(Context context = new Context())
    {
         var entry = context.Entry(employ);
         if(entry.State == EntityState.Detached)
         {
            //Attached it since the record is already being tracked
            context.Employee.Attach(employ);
         }                             
         //Use Remove method to remove it virtually from the memory               
         context.Employee.Remove(employ);
         //Finally, execute SaveChanges method to finalized the delete command 
           to the actual table
         context.SaveChanges();
         //Some stuff here
    }
