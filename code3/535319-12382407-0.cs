    public static List<List<int>> GetSomeInt(List<int> mainList, 
                                             int startIndex, int step)
    {
        var queue = new Queue<int>();
        mainList.ForEach(queue.Enqueue);
    
        Enumerable.Range(0, startIndex)
            .ToList()
            .ForEach(i => queue.Enqueue(queue.Dequeue()));
    
        var result = new List<List<int>>();
    
        while (true)
        {
            var list = queue.Take(step).ToList();
            list.ForEach(i => queue.Enqueue(queue.Dequeue()));
    
            if (result.Any(l => l.All(list.Contains)))
                break;
    
            result.Add(list.ToList());
        }
    
        return result;
    }
