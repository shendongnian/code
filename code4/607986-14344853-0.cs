    public void UpdateFoo(Foo foo)
    {
        context.Foos.Attach(foo); // will throw an exception
        context.Entry(foo).State = EntityState.Modified;
        context.SaveChanges();
    }
