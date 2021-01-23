    // Type: System.Data.EntityState
    public enum EntityState
    {
    Detached = 1,
    Unchanged = 2,
    Added = 4,
    Deleted = 8,
    Modified = 16,
    }
    //See
    Context.Entry(poco).State = state;
