    var collection = o as IEnumerable;
    if (collection != null)
    {
        // It's enumerable...
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
    else
    {
        // It isn't...
    }
