    string json = @"{""method"":""mymethod"",""params"":[1,2],""id"":3}";
    var rpcReq = JsonConvert.DeserializeObject<JsonRpc2Request>(json);
    public class JsonRpc2Request
    {
        [JsonProperty("method")]
        public string Method;
        [JsonProperty("params")]
        public object[] Parameters;
        [JsonProperty("id")]
        public object Id;
    }
