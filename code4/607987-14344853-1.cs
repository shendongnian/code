    public void UpdateFoo(Foo foo)
    {
        if (foo.Bar !=null)
        {
            foo.BarID = foo.Bar.ID;
            foo.Bar = null; // this line is not really necessary
        }
        context.Foos.Attach(foo); // no  exception anymore
        context.Entry(foo).State = EntityState.Modified;
        context.SaveChanges();
    }
