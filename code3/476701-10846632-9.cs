    // this is basically the declaration of one overload of the Where method
    // the this in the parameter declaration, indicates this is an extension method which will be available to all IEnumerable<> objects
    // the Func<T, bool> is the interesting part, it is basically a delegate (as a reminder, the last parameter of the Func object indicates the type that must be returned, in this case is a bool)
    // the delegate is simply a pointer to a function 
    public IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
    
       ...some logic
    
    
       
    
       ... yielding back the reuslts
       foreach(var r in res)
       {
          // here is the delegate in action
           if(predicate(r))
               yield return r;
       }
    }
