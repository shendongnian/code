    using (WebClient wc = new WebClient())
    {
        var json = wc.DownloadString("http://coderwall.com/mdeiters.json");
        var user = JsonConvert.DeserializeObject<User>(json);
    }
-
    public class User
    {
        /// <summary>
        /// A User's username. eg: "sergiotapia, mrkibbles, matumbo"
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        /// <summary>
        /// A User's name. eg: "Sergio Tapia, John Cosack, Lucy McMillan"
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// A User's location. eh: "Bolivia, USA, France, Italy"
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("endorsements")]
        public int Endorsements { get; set; } //Todo.
        [JsonProperty("team")]
        public string Team { get; set; } //Todo.
        /// <summary>
        /// A collection of the User's linked accounts.
        /// </summary>
        [JsonProperty("accounts")]
        public Account Accounts { get; set; }
        /// <summary>
        /// A collection of the User's awarded badges.
        /// </summary>
        [JsonProperty("badges")]
        public List<Badge> Badges { get; set; }
    }
    public class Account
    {
        public string github;
    }
    public class Badge
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("description")]
        public string Description;
        [JsonProperty("created")]
        public string Created;
        [JsonProperty("badge")]
        public string BadgeUrl;
    }
