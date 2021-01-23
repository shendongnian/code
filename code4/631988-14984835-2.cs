    var collection = o as IEnumerable;
    if (collection != null)
    {
        // It's enumerable...
        foreach (var item in collection)
        {
            // Static type of item is System.Object.
            // Runtime type of item can be anything.
            Console.WriteLine(item);
        }
    }
    else
    {
        // It isn't...
    }
