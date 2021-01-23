    public class PostCommentViewModel 
    { 
        public Post Post { get; set; } 
        public IQueryable<Comment> Comment { get; set; } 
     
        public PostCommentViewModel(int postId) 
        { 
            var db = new BlogContext(); 
     
            Post = db.Posts.First(x => x.Id == postId); 
            Comment = Post.Comments; 
        } 
    } 
