    static void AddItem(object item, int priority)
    {
        // Do your magic for your counter as discussed before
        item.counter = uniqueValueHere++;
        item.priority = priority;
    
        // Could do this different ways, i suggest only storing the unique id to reduce footprint
        priorityQueue.InsertWithPriority(item.counter, priority);
        fifoList.Add(item);
    }
    
    static Object RemoveFIFO()
    {
        if (fifoList.Count > 0)
        {
            var removedItem = fifoList[0];
            fifoList.RemoveAt(0);
            RemoveItemFromPriority(removedItem);
            return removedItem;
        }
    }
    
    static void RemoveItemFromPriority(Object itemToRemove)
    {
        foreach (var counter in priorityQueue)
        {
            if (counter == itemToRemove.counter)
            {
                priorityQueue.remove(item);
                break;
            }
        }
    }
    
    static void RemoveFromFIFO(Object itemToRemove)
    {
        foreach (var item in fifoList)
        {
            if (item.counter == itemToRemove.counter)
            {
                fifoList.Remove(item);
                break;
            }
        }
    }
    
    static Object RemoveNextPriority()
    {
        if (priorityQueue.Count > 0)
        {
            var removedItem = priorityQueue.Pop();
            RemoveFromFIFO(removedItem);
            return removedItem;
        }
    }
