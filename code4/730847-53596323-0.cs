    using (var context = new EmployDbContext())
    {
    	Employ emp = context.Employ.Where(x => x.Id == id).Single<Employ>();
    	context.Employ.Remove(emp);
    	context.SaveChanges();
    }
