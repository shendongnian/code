    public void CallMe()
    {
        lock (syncRoot) 
        {
            foreach (CustomObject obj in m_cacheObjects)
            {
                // do something here based on obj
            }
        }
    }
