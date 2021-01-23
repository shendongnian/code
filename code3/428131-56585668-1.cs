    string venName = null;
    WriteName(venName);
    
    public static void WriteName(string name)
    {
        while(String.IsNullOrEmpty(name))
        {
             Console.WriteLine("Venue name - ");
             name = Console.ReadLine();
        }
    }
