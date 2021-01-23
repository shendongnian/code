    void AddItem(int key, Item i, Dictionary<int,List<Item>> dict)
    {
       if (!dict.ContainsKey(key))
       {
          dict.Add(i,new List<Item>());
       }
       dict[key].Add(i);
    }
    
    List<Item> GetList(int key)
    {
       if (dict.ContainsKey(key))
       {
          return dict[key];
       }
       else
       {
          return new List<Item>(); // can also be null
       }
    }
