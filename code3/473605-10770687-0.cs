    using (var context = new SchoolEntities ()) 
    {
         var dpt = new Department { Name = "Mathematics", DepartmentID = 1};
         context.Entry(dpt).State = EntityState.Added;
         context.SaveChanges(); 
    }
