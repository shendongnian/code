        public Dictionary<int, Variation> Variations
        {
            get
            {
                var json = this.VariationsJson.ToString();
                if (json.RemoveWhiteSpace() == EmptyJsonArray)
                {
                    return new Dictionary<int, Variation>();
                }
                else
                {
                    return JsonConvert.DeserializeObject<Dictionary<int, Variation>>(json);
                }
            }
        }
        [JsonProperty(PropertyName = "variations")]
        public object VariationsJson { get; set; }
