    public MyObject DoSomething()
    {
        using (var dbContext = new myContext())
        {
            var foos = new FooHelper(dbContext).GetAllFoos();
            var bah = new bah();
            bah.Foo = foos.First();
            bah.title = "youre a real object";
            new bahHelper(dbContext).Create(bah);
        }
    }
