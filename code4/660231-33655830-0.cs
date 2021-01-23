    public static void Main()
    {
        // Creates and initializes a new ArrayList.
       ArrayList values = new ArrayList();
        Random random = new Random();
        
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
        
        PrintValues(values);
    }
    public static void PrintValues(IEnumerable myList)
    {
        foreach (Object obj in myList)
            Console.Write("   {0}", obj);
        Console.WriteLine(myList);
    }
}
