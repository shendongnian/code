    string set = "abcde";
    
    // Init list
    List<string> subsets = new List<string>();
    
    // Loop over individual elements
    for (int i = 1; i < set.Length; i++)
    {
        subsets.Add(set[i - 1].ToString());
    
        List<string> newSubsets = subsets.Select(t => t + set[i]).ToList();
    
        // Loop over existing subsets
    
        subsets.AddRange(newSubsets);
    }
    
    
    
    // Add in the last element
    subsets.Add(set[set.Length - 1].ToString());
    subsets.Sort((s, s1) =>
                        {
                            var n = s.Length.CompareTo(s1.Length);
                            return n==0 ? s.CompareTo(s1) : n;
                        }
    
        );
    
    Console.WriteLine(string.Join(Environment.NewLine, subsets));
