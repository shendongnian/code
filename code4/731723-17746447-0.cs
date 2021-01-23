    public class JsonUser
    {
        public string Name { get; set; }
        public Dictionary<int, JsonRole> Roles { get; set; }
    }
    public class JsonRole
    {
        public string Name { get; set; }
    }
