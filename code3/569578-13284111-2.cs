    void RunMyMethods(IEnumerable<Item> items)
    {
        foreach(Item item in items)
        {
            var result = MyMethod(item);
            ...
        }
    }
