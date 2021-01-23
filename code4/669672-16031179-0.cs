        //Initial list with ints
        var items = new List<int> {1, 2, 3, 4, 5};
        //ICollection<int> reference
        var collectionOfItems = (ICollection<int>) items;
        //...
        //First of, get collection Type object
        var collectionType = collectionOfItems.GetType();
        //Next, let's grab generic arguments
        var genericArguments = collectionType.GetGenericArguments();
        //For each generic candidate type we need to construct it with collection's generic arguments
        var candidate = typeof(List<>).MakeGenericType(genericArguments);
        //Perform check
        if (collectionType.IsAssignableFrom(candidate))
            Console.WriteLine("Can be casted to {0}", candidate);
        else
            Console.WriteLine("Cannot be cated to {0}", candidate);
