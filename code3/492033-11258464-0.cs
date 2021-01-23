    var items = new ShoppingItems
    {
        Address = "Walstreet,Newyork",
        CustomerName = "John",
        Items = new List<Item>
        {
            new Item { Name = "Milk", Price = "1$"},
            new Item { Name = "IceCream", Price = "1$"},
            new Item { Name = "Bread", Price = "1$"},
            new Item { Name = "Egg", Price = "1$"}
        }
    };
    var xml = new XElement("ShoppingItems",
        new XElement("CustomerName", items.CustomerName),
        new XElement("Address", items.Address),
        items.Items.Select((item,i)=>
            new[] {
                new XElement("Item" + (i + 1), item.Name),
                new XElement("Price" + (i + 1), item.Price)}))
        .ToString();
