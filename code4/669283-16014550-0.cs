    public class StringDictionary : Dictionary<string, string>
    {
        public static implicit operator StringDictionary(string jsonString) 
        {
            return JsonConvert.DeserializeObject<StringDictionary>(jsonString);;
        }
    
        public static implicit operator string(StringDictionary dict) 
        {
            return JsonConvert.SerializeObject(dict);
        }
    }
