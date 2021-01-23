    // In MyClass
    public List<Tbl_Class> GetList()
    {
        using (var db = DatabaseHelper.DataContext())
        {
            return db.tbClass.ToList();
        }
    }
    // In Person
    public List<Tbl_Person> GetList()
    {
        using (var db = DatabaseHelper.DataContext())
        {
            return db.tbPerson.ToList();
        }
    }
