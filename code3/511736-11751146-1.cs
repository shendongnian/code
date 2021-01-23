    public void AddItemIfMissing(int test)
    {
        lock (dictionary)
        {
            if (!dictionary.ContainsKey(test))
            {
               dictionary.Add(test, "Test string");
            }
        }
    }
