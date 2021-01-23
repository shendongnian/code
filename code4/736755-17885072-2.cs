    public List<Table2> GetList(string name)
    {
        List<Table2> list = new List<Table2>();
        list = db.Table2.Where(q => q.NameField = name).ToList();
        return list;
    }
