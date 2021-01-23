    // 1. Data structure to track items we've seen
    var found = new HashSet<Tuple<string, int>>();
    // 2. Data structure to track items we should output
    var output = new HashSet<Tuple<string, int>>();
    // 3. Loop over the input data, storing it into `found`
    using (var input = File.OpenText(path))
    {
        string line;
        while (null != (line = input.ReadLine()))
        {
            // 4. Do your CSV parsing
            var parts = line.Split(','); // <- need better CSV parsing
            var item = Tuple.Create(parts[0], Int32.Parse(parts[1]));
            // 5. Track items we've found and those we should output
            // NB: HashSet.Add returns `false` if it already exists,
            // so we use that as our criteria to mark the item for output
            if (!found.Add(item)) output.Add(item);
        }
    }
    // 6. Output the items
    // NB: you could put this in the main loop and borrow the same strategy
    // we used for `found` to determine when to output an item so that only
    // one pass is needed to read and write the data.
    
