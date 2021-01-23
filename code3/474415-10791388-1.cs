    public class PostsViewModel
    {
        public int Year;
        public List<MonthPosts> Posts;
        public class MonthPosts
        {
            public string Month { get; set; }   // or may be enum with Months
            public List<Post> { get; set;}   // your collection of Posts if they carry many other column values that are needed at the view. If it is just to render the description, instead of list of posts you can pass the list of description of the Posts.
        }
    }
