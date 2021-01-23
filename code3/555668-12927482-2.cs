    public bool Unsubscribe(TKey inEvent, TValue inCallbackMethod)
    {
        List<TValue> list;
        if (!mEventDict.TryGetValue(inEvent, out list))
            return false;
        return list.Remove(inCallbackMethod);
    }
