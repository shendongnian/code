    public static IList<T> TakeMulti<T>(this BlockingCollection<T> me, int count = 100) where T : class
    {
        T last = null;
        if (me.Count == 0)
        {
            last = me.Take(); // blocking when queue is empty
        }
    
        var result = new List<T>(count);
    
        if (last != null)
        {
            result.Add(last);
        }
    
        //if you want to take more item on this time.
        //if (me.Count < count / 2)
        //{
        //    Thread.Sleep(1000);
        //}
    
        while (me.Count > 0 && result.Count <= count)
        {
            result.Add(me.Take());
        }
    
        return result;
    }
