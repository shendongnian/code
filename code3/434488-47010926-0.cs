    foreach(var item in collection.ToList())
    {
        if(item.Name == "Fred")
        {
            collection.Remove(item);
        }
    }
