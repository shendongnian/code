        [JsonIgnoreSerialization]
        public string Prop1 { get; set; } //Will be skipped when serialized
        [JsonIgnoreSerialization]
        public string Prop2 { get; set; } //Also will be skipped when serialized
        public string Prop3 { get; set; } //Will not be skipped when serialized
