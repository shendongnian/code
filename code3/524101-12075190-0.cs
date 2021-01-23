    public class MGDDictionary : Dictionary<string,string>
    {
        public MGDDictionary()
        {
        }
        public static SelectedOption value { get; set; }
        public override string ToString()
        {
            return EntitySerializer.ObjToString<MGDDictionary>(serializer, this);
        }
        public static MGDDictionary FromString(string objectStream)
        {
            return EntitySerializer.FromString<MGDDictionary>(serializer,objectStream);
        }
    }
