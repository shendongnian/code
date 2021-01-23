    void Main()
    {
        var so = new StoreOrder { Date = DateTime.Now };
        var item = new StoreOrderItem {
                Parent = so,
                ItemName = "Hand soap",
                ItemPrice = 2.50m };
        so.Items = new [] { item };
    
        Console.WriteLine(item.Parent.Date);
        Console.WriteLine(so.Items.First().ItemName);
    }
