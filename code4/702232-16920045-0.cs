    Dogs : ISaveable
    Cats : ISaveable
    ...
    Dogs.SaveOrder = 1;
    Cats.SaveOrder = 2;
    ...
    List<ISaveable> saveItems = new List<ISaveable>();
    ...
    saveItems.Add(Dogs);
    saveItems.Add(Cats);
    ...
    foreach(var item in saveItems.OrderBy(q=>q.SaveOrder))
    {
       item.Save();
    }
