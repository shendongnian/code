    const int MAX_ITEMS = 10;
    List<int> list = new List<int>();
    void AddItem(int k)
    {
        list.Add(k);
        if (list.Count > MAX_ITEMS)
        {
            // discard the item at the front of the list
            list.RemoveAt(0);
        }
    }
