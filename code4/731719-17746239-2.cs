    public class User
    {
        public string Name { get; set; }
        [JsonConverter(typeof(RolesConverter))]
        public Role[] Roles { get; set; }
    }
