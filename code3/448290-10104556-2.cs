    List<string> collection1 = new List<string> { "a", "b", "c", "d" };
    var collection2 = Enumerable.Range(0, weight + 1);
    collection1 = collection1.Concat(collection2.Select(i => i.ToString())).ToList();
   
    var permutations = new Facet.Combinatorics.Permutations<String>(collection1);
    foreach (IList<String> p in permutations)
    {
        String combi = String.Join("", p);
    }
