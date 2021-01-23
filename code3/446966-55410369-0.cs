    public List<T> GetRandomItems(List<T> items, int count = 3)
    {
        var length = items.Count();
        var list = new List<T>();
        var rnd = new Random();
        var seed = 0;
        while (list.Count() < count)
        {
            seed = rnd.Next(0, length);
            if(!list.Contains(items[seed]))
                list.Add(items[seed]);
        }
           
        return list;
    }
