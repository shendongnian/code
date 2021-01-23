    private Dictionary<TKey, List<TValue>> mEventDict;
    
    public void Subscribe(TKey inEvent, TValue inCallbackMethod)
    {
        if (!mEventDict.ContainsKey(inEvent))
            mEventDict.Add(inEvent, new List<TValue>());
    
        mEventDict[inEvent].Add(inCallbackMethod);
    }
    public bool Unsubscribe(TKey inEvent, TValue inCallbackMethod)
    {
        if (!mEventDict.ContainsKey(inEvent))
            return false;
    
        bool removed = mEventDict[inEvent].Remove(inCallbackMethod);
    
        if (mEventDict[inEvent].Count == 0)
            mEventDict.Remove(inEvent);
    
        return removed;
    }
