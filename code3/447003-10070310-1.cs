    // In DatabaseHelper:
    public static List<T> GetList<T>()
    {
        using (var db = DataContext())
        {
            return db.GetTable<T>().ToList();
        }
    }
    // In MyClass
    public List<Tbl_Class> GetList()
    {
        return DatabaseHelper.GetList<Tbl_Class>();
    }
    // In Person
    public List<Tbl_Person> GetList()
    {
        return DatabaseHelper.GetList<Tbl_Person>();
    }
