    var wordlist = " aa bb cc ccc ddd ddd aa ";
    var lookup = wordlist.Trim().Split().Distinct().ToLookup(word => word.Length);
    foreach (var grouping in lookup)
    {
        // grouping.Key contains the word length of the group
        Console.WriteLine("Words with length {0}:", grouping.Key);
        foreach (var word in grouping)
        {
            // do something with every word in the group
            Console.WriteLine(word);
        }
    }
