    public bool IsDeleted
    { 
        get {
            return ChangeTracker.State == ObjectState.Deleted
        } 
    }
