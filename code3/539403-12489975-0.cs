    using (var context = new Db())
    {
        var entity = context.SomeSet.Find(id);
    
        context.Entry(entity).Collection(p => p.SomeCollection).Load();
    }
