    public class VarationsContainer
    {
        [JsonIgnore]
        public Varation[] Varations
        {
            get
            {
                return ParseObjectToArray<Variation>(VariationObject);
            }
        }
        [JsonProperty(PropertyName = "varations")]
        public object VarationsObject { get; set; }
        protected T[] ParseObjectToArray<T>(object ambiguousObject)
        {
            var json = ambiguousObject.ToString();
            if (String.IsNullOrWhiteSpace(json))
            {
                return new T[0]; // Could return null here instead.
            }
            else if (json.TrimStart().StartsWith("["))
            {
                return JsonConvert.DeserializeObject<T[]>(json);
            }
            else
            {
                return new T[1] { JsonConvert.DeserializeObject<T>(json) };
            }
        }
    }
