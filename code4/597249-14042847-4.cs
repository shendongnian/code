    // lock entire business transaction if possible
    public void UpdateEntity(int a, int b)
    {
       lock (entityLock)
       {
           Int1 = a;
           Int2 = b;
        }
    }    
