        public class Attribute {
            [JsonProperty(PropertyName = "nbrOfUse")]
            public int _nbrOfUse { get; set; }
            [JsonProperty(PropertyName = "streetType")]
            [Display(Name = "lastUse", ResourceType = typeof(AccountModels))]
            public string _lastUse { get; set; }
            
        }
