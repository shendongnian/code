    public class InterfaceContractResolver : DefaultContractResolver
    {
        private readonly Type _InterfaceType;
        public InterfaceContractResolver (Type InterfaceType)
        {
            _InterfaceType = InterfaceType;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            //IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            IList<JsonProperty> properties = base.CreateProperties(_InterfaceType, memberSerialization);
            return properties;
        }
    }
    // To serialize do this:
    var settings = new JsonSerializerSettings() {
         ContractResolver = new InterfaceContractResolver (typeof(IThing))
    });
    string json = JsonConvert.SerializeObject(theObjToSerialize, settings);
                     
                                
