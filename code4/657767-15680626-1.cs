    List<Item> items = new List<Item>();
    items.Add(new Item() { Id = 1, ParentId = 0 });
    items.Add(new Item() { Id = 2, ParentId = 0 });
    items.Add(new Item() { Id = 3, ParentId = 0 });
    items.Add(new Item() { Id = 4, ParentId = 1 });
    items.Add(new Item() { Id = 5, ParentId = 1 });
    items.Add(new Item() { Id = 6, ParentId = 4 });
    items.RemoveAll(input => items.Count(item => item.Id == input.ParentId) > 0);
    //those who remain
    // item with Id = 1
    // item with Id = 2
    // item with Id = 3
