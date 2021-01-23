    public class tweet
    {
        public string max_id_str { get; set; }
        //public string text{ get; set; }
        public List<result> results { get; set; }
        public string results_per_page{ get; set; }
        public string since_id { get; set; }
        public string since_id_str { get; set; }
    }
    
    public class result
    {
        public string created_at { get; set; }
        public string from_user { get; set; }
        public int from_user_id { get; set; }
        public string text { get; set; }
    }
