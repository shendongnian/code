    public class PriorityQueue<TPriority, TElement>
    {
        SortedDictionary<TPriority, Queue<TElement>> dictionary = new SortedDictionary<TPriority, Queue<TElement>>();
        public PriorityQueue()
        {
        }
    
        public Tuple<TPriority, TElement> Peek()
        {
            var firstPair = dictionary.First();
            return Tuple.Create(firstPair.Key, firstPair.Value.First());
        }
    
        public TElement Pop()
        {
            var firstPair = dictionary.First();
            TElement output = firstPair.Value.Dequeue();
    
            if (!firstPair.Value.Any())
                dictionary.Remove(firstPair.Key);
    
            return output;
        }
    
        public void Push(TPriority priority, TElement element)
        {
            Queue<TElement> queue;
            if (dictionary.TryGetValue(priority, out queue))
            {
                queue.Enqueue(element);
            }
            else
            {
                var newQueue = new Queue<TElement>();
                newQueue.Enqueue(element);
                dictionary.Add(priority, newQueue);
            }
        }
    }
