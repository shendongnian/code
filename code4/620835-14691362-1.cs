    public class RootObject
    {
        [ JsonProperty, JsonConverter( typeof( DictionaryConverter<string, postModel> ) ) ]
        public Dictionary<string, postModel> posts;
    }
