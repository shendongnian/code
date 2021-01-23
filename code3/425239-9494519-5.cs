    class NameElement
    {
        public string name { get; set; }
        public string element { get; set; }
    }
    IEnumerable<NameElement> GetResults(Dictionary<string, MyStruct> dict)
    {
        foreach (KeyValuePair<string, MyStruct> t in dict)
            foreach (string v in t.Value.elements)
                yield return new NameElement { name = t.Key, element = v };
    }
