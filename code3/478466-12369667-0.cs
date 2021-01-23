    public static Func<dynamic, MyDbObject> TableToMyDbObject =
        (row) => new MyDbObject
                     {
                         Id = row.Id
                     }
