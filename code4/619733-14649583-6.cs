    E2 child = new E2 { Id = 1 };
    context.Entry(child).State = System.Data.EntityState.Unchanged;
    E1 new1 = new E1
    {
        Child = child
    };
    // Add a single entity.
    context.E1s.Add(new1);
    Debug.Assert(context.Entry(new1.Child).State == System.Data.EntityState.Unchanged);
    Debug.Assert(context.Entry(new1).State == System.Data.EntityState.Added);
