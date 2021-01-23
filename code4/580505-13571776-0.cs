    var jsonObj = JsonConvert.DeserializeObject<RootObject>(json);
    public class RootObject
    {
        [JsonProperty("server")]
        public string Server;
        [JsonProperty("disks")]
        public List<Drive> Disks;
    }
    public class Drive
    {
        [JsonProperty("use")]
        public string Usage;
        [JsonProperty("used")]
        public string usedSpace;
        [JsonProperty("mount")]
        public string Mount;
        [JsonProperty("free")]
        public string freeSpace;
        [JsonProperty("device")]
        public string Device;
        [JsonProperty("total")]
        public string Total;
        [JsonProperty("type")]
        public string Type;
    }
