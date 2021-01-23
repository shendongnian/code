    private Dictionary<TKey, List<TValue>> mEventDict;
    public void Subscribe(TKey inEvent, TValue inCallbackMethod)
    {
        List<TValue> list;
        if (mEventDict.TryGetValue(inEvent, out list))
            list.Add(inCallbackMethod);
        else
            mEventDict.Add(inEvent, new List<TValue> { inCallbackMethod });
    }
    public bool Unsubscribe(TKey inEvent, TValue inCallbackMethod)
    {
        List<TValue> list;
        if (!mEventDict.TryGetValue(inEvent, out list))
            return false;
        bool removed = list.Remove(inCallbackMethod);
        if (list.Count == 0)
            mEventDict.Remove(inEvent);
        return removed;
    }
