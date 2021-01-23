    // Ensure your objects implement a common interface.
    Dogs : ISaveable
    Cats : ISaveable
    ...
    // The interface (not shown) has a SaveOrder
    Dogs.SaveOrder = 1;
    Cats.SaveOrder = 2;
    ...
    // Create a container that is capable of holding items implementing ISaveable 
    List<ISaveable> saveItems = new List<ISaveable>();
    ...
    // Add your items to your container
    saveItems.Add(Dogs);
    saveItems.Add(Cats);
    ...
    // When it's time to save, simply enumerate through your container
    foreach(var item in saveItems.OrderBy(q=>q.SaveOrder))
    {
       // The interface guarantees that a Save method exists on each object
       item.Save();
    }
