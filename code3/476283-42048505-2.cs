    using (var context = new MyContext())
    {
        var parentObject = context.ParentObject.Find(1);
        parentObject.ChildObjects.Add(new ChildObject());
        context.SaveChanges();
    }
    using (var context = new MyContext())
    {
        var parentObject = context.ParentObject.Find(1);
        parentObject.ChildObjects.Clear();
        context.SaveChanges();
    }
