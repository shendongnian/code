    T item;
    
    SpinLock sl = new SpinLock();
    
    public T Item
    {
        get 
        { 
            bool lockTaken = false;
    
            try
            {
                sl.Enter(ref lockTaken);
                return item; 
            }
            finally
            {
                if (lockTaken) sl.Exit();
            }
        }
        set 
        {
            bool lockTaken = false;
    
            try
            {
                sl.Enter(ref lockTaken);
                item = value;
            }
            finally
            {
                if (lockTaken) sl.Exit();
            }
        }
    }
