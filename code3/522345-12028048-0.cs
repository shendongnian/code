    public static class Helpers
    {
     
        public static Ent LoadStub<Ent>(this DbContext db, object id) where Ent : class
        {
            string primaryKeyName = typeof(Ent).Name + "Id";
            return db.LoadStub<Ent>(primaryKeyName, id);
        }
     
        public static Ent LoadStub<Ent>(this DbContext db, string primaryKeyName, object id) where Ent: class
        {
            var cachedEnt = 
                db.ChangeTracker.Entries().Where(x => ObjectContext.GetObjectType(x.Entity.GetType()) == typeof(Ent)).SingleOrDefault(x =>
                {
                    var entType = x.Entity.GetType();
                    var value = entType.InvokeMember(primaryKeyName, System.Reflection.BindingFlags.GetProperty, null, x.Entity, new object[] { });
     
                    return value.Equals(id);
                });
     
            if (cachedEnt != null)
            {
                return (Ent) cachedEnt.Entity;
            }
            else
            {
                Ent stub = (Ent) Activator.CreateInstance(typeof(Ent));
     
                 
                typeof(Ent).InvokeMember(primaryKeyName, System.Reflection.BindingFlags.SetProperty, null, stub, new object[] { id });
     
     
                db.Entry(stub).State = EntityState.Unchanged;
     
                return stub;
            }
     
        }
    }
