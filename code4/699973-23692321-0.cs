        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("Age")]
        public int required { get; set; }
        [JsonProperty("Location")]
        public string type { get; set; }
    and Remove a "{"..,
       strFieldString = strFieldString.Remove(0, strFieldString.IndexOf('{'));
   
    DeserializeObject..,
       optionsItem objActualField = JsonConvert.DeserializeObject<optionsItem(strFieldString);
