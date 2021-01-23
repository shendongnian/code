    this.items = new List<Item>();
    items.Add(new Item() { Id = 1, ParentId = 2 });
    items.Add(new Item() { Id = 2, ParentId = 0 });
    items.Add(new Item() { Id = 3, ParentId = 0 });
    items.Add(new Item() { Id = 4, ParentId = 1 });
    items.Add(new Item() { Id = 5, ParentId = 1 });
    items.Add(new Item() { Id = 6, ParentId = 4 });
    items.Add(new Item() { Id = 7, ParentId = 4 });
    items.Add(new Item() { Id = 8, ParentId = 4 });
    items.Add(new Item() { Id = 9, ParentId = 4 });
    items.Add(new Item() { Id = 10, ParentId = 4 });
    items.Add(new Item() { Id = 11, ParentId = 4 });
    var res =
        (from i in this.items
         where items.Any(input => input.Id == i.ParentId)
         select i).ToList();
    items.RemoveAll(input => res.Contains(input));
    //Those who remain
    //item with Id = 2
    //item with Id = 3
