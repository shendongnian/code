    public class PostBase{
        public ICollection<Comment> Comments{get; set; }
    }
    
    
    public class Post:PostBase
    {
        public string Title {get; set;}
    
    }
    
    public class Photo:PostBase
    {
        public string Path{get;set;}
    
    }
    
    public class Comment
    {
        public int? PostBaseId{get;set;}
        public Virtual PostBase PostBase{get;set;}
    
    }
