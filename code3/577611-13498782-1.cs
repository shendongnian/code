    public static IObservable<int> WhenLastObservedChangesByMoreThan(
        this IObservable<int> observable, int tolerance)
    {
        // Validate parameters.
        if (observable == null) throw new ArgumentNullException("observable");
        // Tolerance must be positive, so comparisons are correct after
        // addition/subtraction.
        if (tolerance < 0) 
            throw new ArgumentOutOfRangeExeption("tolerance", tolerance,
                "The tolerance parameter must be a non-negative number.");
        // Shortcut: If tolerance is 0, then every value is returned, just
        // return the observable.
        if (tolerance == 0) return observable;
        
        // The last value yielded.
        int? lastYielded = null;
    
        // Filter.
        observable = observable.Where(i => {
            // If there is a previous value
            // that was yielded.
            if (lastYielded != null)
            {
                // Is the last value within
                // tolerance?
                if (i - tolerance < i && i < i + tolerance)
                {
                    // Do not process.
                    return false;
                }
            }
        
            // This is being yielded, store the value.
            lastYielded = i;
        
            // Yield the value.
            return true;
        });
    }
