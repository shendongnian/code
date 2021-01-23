    List<Item> list = new List<Item>
    {
        new Item { ID = 0, Name = "John", Category = "Police"}, 
        new Item { ID = 1, Name = "Michael", Category = "Police"},
        new Item { ID = 2, Name = "Alice", Category = "Police"}, 
        new Item { ID = 3, Name = "Ferdinand", Category = "Thief"}, 
        new Item { ID = 4, Name = "Jocas", Category = "Thief"}, 
        new Item { ID = 5, Name = "Connor", Category = "Thief"}
    };
    var results = list.GroupBy(x => x.Category).SelectMany(g => g.Take(2)).ToList();
