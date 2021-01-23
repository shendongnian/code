    IEnumerable<MyClass> GetMyClasses(int id) {
        return GetQuery().Where(p => p.Id==id); // this always will work as IQueryable and handled by provider (in case of EF - the DB query will be performed)
    }
    IEnumerable<MyClass> MoreRestrictions(int id) {
         return GetMyClasses(id)
             .ToList(); // result list will be filtered by Id
    }
    IEnumerable<MyClass> MoreRestrictions(int id) {
         return GetMyClasses(id)
             .Where(x=>x.IsActive) // this where will be performed in memory on results filtered by Id.
             .ToList(); 
    }
