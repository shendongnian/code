        // Creating test data
        var dictionary = new Dictionary<int, IList<int>>
        {
            { 1, new List<int> { 2, 1, 6 } },
            { 5, new List<int> { 2, 1 } },
            { 2, new List<int> { 2, 3 } }
        };
        
        // Ordering as requested
        dictionary = dictionary
            .OrderBy(d => d.Key)
            .ToDictionary(
                d => d.Key,
                d => (IList<int>)d.Value.OrderBy(v => v).ToList()
            );
        
        // Displaying the results
        foreach(var kv in dictionary)
        {
            Console.Write("\n{0}", kv.Key);
            foreach (var li in kv.Value)
            {
                Console.Write("\t{0}", li);
            }
        }
