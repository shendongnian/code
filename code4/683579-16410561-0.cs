    private void CreateObjects()
    {
        for (int i = 0; i < 100; i++)
        {
            MyObject o = new MyObject();
            o.OnFinished += OnMyObjectFinished;
            m_myObjectCollection.TryAdd(i.ToString(), o);
        }
    }
