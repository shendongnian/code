    class Foo
    {
        static void doStuff()
        {
            var foo = new Dictionary<Foo, Bar>(); // Create instance
            fooBar.Add(new Foo(), new Bar()); // No error :)
        }
    }
