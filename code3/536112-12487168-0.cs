    struct YearValue 
    {
        public int Year, Value; 
    }
    static void Main()
    {
        // Create some data, hopefully representative of what you are dealing with...
        Random r = new Random();
        YearValue[] dataValues = new YearValue[22];
        for (int i = 0; i < dataValues.Length; i++)
            dataValues[i] = new YearValue {Year = i, Value = r.Next(200)};
        // Average of values across 'ReviewPeriod' of five:
        foreach (var item in dataValues.AsEnumerable().GroupBy(i => i.Year / 5))
        {
            YearValue[] items = item.ToArray();
            Console.WriteLine("Group {0} had {1} item(s) averaging {2}",
                              item.Key,
                              items.Length,
                              items.Average(i => i.Value)
                );
        }
    }
