    public static int Method<T>(this thisType me, Expression<Func<T, Boolean>> Predicate)
    {
        var allOfEm = me.Uow.X.GetAll().Where(Predicate);
        var s1 = allOfEm
                  .SelectMany(a => a.OrganizationalUnits.Where(q => Identity.Y.Contains(q.Z)))
                  .Distinct();
    
        var s2 = allOfEm
                  .SelectMany(a => a.Classes.Where(q => Identity.Y.Contains(q.K)))
                  .Distinct();
    
        var s3 = allOfEm
                  .SelectMany(a => a.Courses.Where(q => Identity.Y.Contains(q.L)))
                  .Distinct();
    
        return s1.Count() + s2.Count() + s3.Count();
    }
