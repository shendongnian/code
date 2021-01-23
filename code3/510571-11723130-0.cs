    public void DoSomething<TObj>(IEnumerable<AtomicObject<TObj>, Object> dict) 
        where TObj : ICopyable {
        foreach (KeyValuePair<AtomicObject<TObj>, Object> entry in dict)
        {
            ICopyable dest = entry.Key.openRead();
            // Whatever...
        }
    }
