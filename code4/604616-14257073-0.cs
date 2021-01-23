    public static IEnumerable<myObject> getAll(Expression<Func<myObject,bool>> where)
    {
        using (var db = Database.OpenConnectionString(blahblah))
        {
            var queryResults = db.Query("SELECT * FROM vu_myObjects");
            if (where != null)
            {
                queryResults.Where(where);
            }
            return queryResults .Select(x => new myObject(x.myObjectName, x.myObjectF));
        }
    }
    public static IEnumerable<myObject> getAllForFilter(String filter)
    { // Not checked syntax.
        return getAll(x => x.ObjectF = filter);
    }
