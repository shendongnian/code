    var itemToAdd = context.Items( i => i.Property == "Desired" );
    MyClass myclass = new MyClass()
    {
        Items = new List<Item>(itemToAdd) // You can pass any collection of IEnumerable here.
    }
