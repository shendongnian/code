    IEnumerable<T> things = GetThings();
    
    Cache["ThingCache"] = things;
    
    T aThing = ((IEnumerable)Cache["ThingCache"]).First();
    
    //Cache["ThingCache"] should still contain the original collection.
