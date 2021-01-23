    public void UpdateSession(string correlationKey)
    {
        var dictionary = Application["ProcessedQueue"] as Dictionary<string, int>;
        if (dictionary == null)
        {
            dictionary = new Dictionary<string, int>();
            Application["ProcessedQueue"] = dictionary;
        }
        if (!dictionary.ContainsKey(correlationKey)) { dictionary.Add(correlationKey, 0); }
        for (int i = 0; i< 100; i++)
        {
            dictionary[correlationKey] =  i;
            System.Threading.Thread.Sleep(1000);
        }
    }
