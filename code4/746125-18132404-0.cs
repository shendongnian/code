    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
    
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
