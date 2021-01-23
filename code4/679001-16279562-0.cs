    public class JsonPetShelters
    {
        [JsonProperty("@encoding")]
        public string Encoding { get; set; }
        [JsonProperty("@version")]
        public string Version { get; set; }
        [JsonProperty("petfinder")]
        public Petfinder Petfinder { get; set; }
        internal JsonPetShelters() {}
    }
