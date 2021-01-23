    Thing[] things = ...;
    for (int i = 0; i < things .Length; i++)
    {
      AddOne(ref things[i]);
    }
    public void AddOne(ref Thing t)
    {
      t.Foo += 1;
    }
