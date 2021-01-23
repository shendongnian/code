    using(var context = new MyLinqDbContext())
    {
        var items = (from i in context.MyTable
                     select new ItemViewModel { id = ID, name = Name })
                    .ToList();
    }
