    var heap = new BinaryHeap<int>();
    
    for (int i = 0; i < 1000; ++i)
    {
        var time = GetTimeSomehow();
        if (heap.Count < 5)
        {
            heap.Insert(time);
        }
        else if (time > heap.Peek())
        {
            // the new value is larger than the smallest value on the heap.
            // remove the smallest value and add this one.
            heap.RemoveRoot();
            heap.Insert(time);
        }
    }
