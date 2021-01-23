    public List<int> GetNumber()
    {
        Random random = new Random();
        List<int> values = new List<int>();
        values.Add(random.Next(0, 25));
        while (values.Count < 10)
        {
            int newValue;
            do
            {
                newValue = random.Next(0, 25);
            } while (values.Contains(newValue));
            values.Add(newValue);
        }
        return values;
    }
