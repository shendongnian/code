    public int Add(FruitTrees newItem)
    {
        if (First == null)
        return Add_Initialize(newItem);
        FruitTrees item = First;
        while (item.Next != null)
        {
            item = item.Next;
        }
        item.Next = newItem;
        Last = newItem;
        return size++;
    }
