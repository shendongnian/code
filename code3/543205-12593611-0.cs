    private static Dictionary<string, int> values = new Dictionary<string, int>();
    private static void Add(string newValue)
    {
        if(values.ContainsKey(newValue))
        {
            values[newValue]++;  // Increment count of existing item
        }
        else
        {
            values.Add(newValue, 1);  // Add new item with count 1
        }
    }
