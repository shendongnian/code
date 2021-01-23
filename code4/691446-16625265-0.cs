    public class Posts
    {
        public List<Products> posts { get; set; }
    }
    
    public class Products
    {
        public List<Info> post { get; set; }
    }
    
    public class Info
    {
        public string pd_id { get; set; }
        public string pd_name {get; set; }
    }
