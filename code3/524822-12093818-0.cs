    private IDictionary<string, int> StringToBag(string str)
    {
        return str.Split(',').GroupBy(s => s).ToDictionary(g => g.Key, g => g.Count());
    }
    private bool BagContains(IDictionary<string, int> haystack, IDictionary<string, int> needle)
    {
        return needle.All(kv => haystack.ContainsKey(kv.Key) && kv.Value <= haystack[kv.Key]);
    }
    
    var bag = StringToBag("banana,banana,cherry,kiwi,strawberry");
    bool contained = BagContains(bag, StringToBag("banana,strawberry"));
