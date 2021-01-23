    public class BlogEntry 
    {
        private BlogEntry() {}
        public BlogEntry(string title, string body)
        {
            LastModifiedDate = DateTime.Now;
            Title = title;
            Body = body;
            var blogEntryValidator = new BlogEntryValidator();
            blogEntryValidator.ValidateAndThrow(this);     
        }
    
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public DateTime? LastPublishDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public virtual ICollection<Comment> Comments { get; private set; }        
    
        public void Publish()
        {
            LastPublishDate = DateTime.Now;
        }
    
        public void Unpublish()
        {
            LastPublishDate = null;
        }
    
        public void Modify(string title, string body)
        {
            Title = title;
            Body = body;
            LastModifiedDate = DateTime.Now;
        }
    
        public Comment AddComment(string commentText, string emailAddress, string name)
        {
            var comment = new Comment(this, commentText, emailAddress, name);
            if (Comments == null) Comments = new List<Comment>();
            Comments.Add(comment);
            return comment;
        }
    
        public void RemoveComment(Comment comment)
        {
            Comments.Remove(comment);
        }
    }
    
    public class Comment 
    {
        private Comment() {}
        public Comment(BlogEntry blogEntry, string name, string emailAddress, string commentText)
        {            
            BlogEntry = blogEntry;
            Name = name;
            EmailAddress = emailAddress;
            CommentText = commentText;
            DateWritten = DateTime.Now;
            var commentValidator = new CommentValidator();
            commentValidator.ValidateAndThrow(this);    
        }
    
        public int Id { get; private set; }        
        public string Name { get; private set; }
        public string EmailAddress { get; private set; }
        public string CommentText { get; private set; }
        public DateTime DateWritten { get; private set; }
        public BlogEntry BlogEntry { get; private set; }
    }
