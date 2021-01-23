    public void ForEach(Action<T> action)
    {
        // Error handling omitted
    
        // Cycle through the items, perform action.
        for (int index = 0; index < Count; ++index)
        {
            // Perform action.
            action(this[index]);
        }
    }
