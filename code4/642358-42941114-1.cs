    public class TestDataModel
    {
        public string AgencyId;
        public int Years;
        public PropertyBagModel Overrides;
    }
    public class ParticipantFilterModel
    {
        public string[] ClassAndTier;
        public string[] BargainingUnit;
        public string[] Department;
    }
    public class PropertyBagModel
    {
        [JsonExtensionData]
        private readonly Dictionary<string, JToken> _extensionData = new Dictionary<string, JToken>();
        [JsonIgnore]
        public readonly Dictionary<string, string> Values = new Dictionary<string, string>();
        [JsonProperty(".plan", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, PropertyBagModel> ByPlan;
        [JsonProperty(".classAndTier", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, PropertyBagModel> ByClassAndTier;
        [JsonProperty(".bargainingUnit", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, PropertyBagModel> ByBarginingUnit;
        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            foreach (var kvp in Values)
                _extensionData.Add(kvp.Key, kvp.Value);
        }
        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            _extensionData.Clear();
        }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Values.Clear();
            foreach (var kvp in _extensionData.Where(x => x.Value.Type == JTokenType.String))
                Values.Add(kvp.Key, kvp.Value.Value<string>());
            _extensionData.Clear();
        }
    }
