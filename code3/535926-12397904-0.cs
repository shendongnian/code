    // Inside of MyObject class
    [DataMember]
    public Kvp<string, string>[] Dictionary { get; set; }
    public Dictionary<string, string> GetDictionary()
    {
        return Dictionary.ToDictionary(x => x.Key, x => x.Value);
    }
    //////////////////
    public class Kvp<T1, T2>
    {
        public T1 Key { get; set; }
        public T2 Value { get; set; }
    }
    Dictionary<string, string> myDictionary = myObjects[0].GetDictionary();
