    // lock entire business transaction if possible
    public void UpdateEntity(int a, int b)
    {
       lock (entityLock)
       {
           PropertyA = a;
           PropertyB = b;
        }
    }    
