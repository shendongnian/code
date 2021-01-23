    public static int  InsertAllOnSubmit<T>(
        this ObjectContext db, T instance, IList<T> newentities)
        where T : EntityObject
    {
        var objectSet = db.CreateObjectSet<T>();
        newentities.ForEach(x => objectSet.AddObject(x));
        int inserted = db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
        return inserted;
    } 
