    public class PostsViewModel
    {
        public int Year;
        public List<MonthPosts> Posts;
        public class MonthPosts
        {
            public string Month { get; set; }
            public List<Post> { get; set;}
        }
    }
