    public class LoginResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public DateTime ExpiresIn { get; set; }
        [JsonProperty("userName")]
        public string Username { get; set; }
        [JsonConverter(typeof(CustomDateFormat), "EEE, dd MMM yyyy HH:mm:ss zzz")]
        [JsonProperty(".issued")]
        public DateTime Issued { get; set; }
        [JsonConverter(typeof(CustomDateFormat), "MMMM dd, yyyy")]
        [JsonProperty(".expires")]
        public DateTime Expires { get; set; }
    }
    public class CustomDateFormat : IsoDateTimeConverter
    {
        public CustomDateFormat(string format)
        {
            DateTimeFormat = format;
        }
    }
