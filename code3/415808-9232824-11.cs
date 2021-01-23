    static Object RemoveNextFIFO()
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
    
    static Object RemoveFromFIFO(int itemCounter)
    {
        foreach (var item in fifoList)
        {
            if (item.counter == itemCounter)
            {
                fifoList.Remove(item);
                return item;   
            }
        }
    }
    
    static Object RemoveNextPriority()
    {
        if (priorityQueue.Count > 0)
        {
            var counter = priorityQueue.Pop();
            return RemoveFromFIFO(counter);
        }
    }
