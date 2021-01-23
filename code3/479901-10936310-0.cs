    Random rand = new Random();
    string[] words = iTemplate.Text.Split(' ');
    // Insert dots onto at least 4 words
    int numInserts = rand.Next(4, words.Count());
    // Used later to store which indexes have already been used
    Dictionary<int, bool> usedIndexes = new Dictionary<int, bool>();
    for (int i = 0; i < numInserts; i++)
    {
    	int idx = rand.Next(1, words.Count());
    	// Don't process the same word twice
    	while (usedIndexes.ContainsKey(idx))
    	{
    		idx = rand.Next(1, words.Count());
    	}
             // Mark this index as used
    	usedIndexes.Add(idx, true);
    	// Append the dots
    	string word = words[idx];
    	for (int dots = rand.Next(1, 7); dots > 0; dots--)
    		word += ".";
    	words[idx] = word;
    }
    // String.Join will put the separator between each word,
    //without the trailing " "
    string result = String.Join(" ", words);
    Console.WriteLine(result);
