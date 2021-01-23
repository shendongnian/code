    readonly object lockObject = new Object();
    void check()
    {
        lock (lockObject)
        {
            foreach (GetAll g in GetAllInList)
            {
                InIgnoreList(g);
            }
        }
    }
