    static Dictionary<string, int> Priorities = new Dictionary<string, int>();
    static void Main(string[] args)
    {
        var itineraries = new string[][]{   
            new string[] { "C", "B", "D", "F", "A" },
            new string[] { "C", "B", "D", "F" },
            new string[] { "A", "C", "B", "E" },
            new string[] { "A", "B", "C", "D" } };
        //process past itineraries
        foreach (var itinerary in itineraries)
            ProcessItinerary(itinerary);
        //sort new itinerary
        string[] newItinerary = { "A", "B", "C", "D", "E", "F" };
        string[] sortedItinerary = newItinerary.OrderByDescending(
            x => Priorities.ContainsKey(x) ? Priorities[x] : 1).ToArray();
        Console.WriteLine(String.Concat(sortedItinerary));
        Console.ReadKey();
    }
    static void ProcessItinerary(string[] itinerary)
    {
        itinerary.Reverse().Aggregate((below, above) =>
        {
            int priBelow = Priorities.ContainsKey(below) ?
                Priorities[below] : Priorities[below] = 1;
            if (!(Priorities.ContainsKey(above) &&
                Priorities[above] > priBelow))
                Priorities[above] = priBelow + 1;
            return above;
        });
        //normalize priorities
        // (note: running in reverse so that if priorities tie, 
        //  the older location has higher priority)
        int i = Priorities.Count;
        foreach (var pair in Priorities.OrderByDescending(x => x.Value))
            Priorities[pair.Key] = i--;
    }
