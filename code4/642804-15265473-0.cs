    var collection = new Collection<Foo>
                             {
                                 new Foo {Name = "Name1"},
                                 new Foo {Name = "Name2"},
                                 new Foo {Name = "Name3"},
                                 new Foo {Name = "Name4"}
                             };
        var newCollection = new List<Foo>(collection);
    
        Foo f = collection.FirstOrDefault(x => x.Name == "Name2");
        if (f != null)
        {
            newCollection.Remove(f);
        }
