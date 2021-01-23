    void M()
    {
        using (Stream x = ...)
        {
        }
        using (Stream x = ...)
        {
        }
        for (int x = 0; x < 10; x++)
        {
        }
        // Block introduced just for scoping...
        {
            string x = "";
            ...
        }
    }
