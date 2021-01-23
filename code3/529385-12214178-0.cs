    IEnumerable<I> myObjects;
    using(var context = new MyDbContext())
    {
        myObjects = context.Set<I>.Where(x => x.Name == "Test");
    }
    foreach(obj in myObjects)
    {
        var name = obj.Name; //BOOM! Context is disposed.
    }
