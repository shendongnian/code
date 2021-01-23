        List<Item> list = new List<Item>();
        list.Add(new Item(10));
        list.Add(new Item(2));
        list.Add(new Item(5));
        list.Add(new Item(18));
        list.Add(new Item(1));
        list.Sort((a, b) => { return a.Layer.CompareTo(b.Layer); });
