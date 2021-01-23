    FetchData(x)
    {
        SomeBO obj = new SomeBO();
        using(var context = new DatabaseDataContext())
        {
            obj.Prop1 = context.Table2s.Where(t2 => t2.Id == x.Id)
                               .FirstOrDefault().col;
            ...
        }
    }
