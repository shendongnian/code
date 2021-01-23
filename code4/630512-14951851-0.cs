    class Item
    {
        public int X;
        public string Y;
    }
    var items = new Item[100];
    var ordered = items.OrderBy<Item, string>(i => i.Y);
