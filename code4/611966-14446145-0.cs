    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public virtual ICollection<Post> PostsThisUserLikes {get;set;}
    }
    public class Post
    {
        public int ID { get; set; }
        public string Contents { get; set; }
        public virtual ICollection<User> UsersWhoLikeThis { get; set; }
    }
