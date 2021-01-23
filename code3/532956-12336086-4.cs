    public class FakeMyResponse
    {
        public ResponseBlog blog { get; set; }
        public Post[] posts { get; set; }
        
        public FakeMyResponse(MyResponse response)
        {
            blog = response.blog;
            posts = response.posts;
        }
    }
