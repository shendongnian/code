    public static void InsertAllListsOnSubmit(
        this ObjectContext db, IList<IList<object>> lists)
    {
        foreach (IList<object> list in lists)
        {
            if (list.Count > 0)
            {
                dynamic instance = list[0];
                db.InsertAllOnSubmit(instance, list);
            }
        }
    }
