    public class Task
    {
        private readonly IList<Comment> Comments = new List<Comment>();
        public void AddComment(ICommentBuilderFinalization commentBuilder)
        {
            Comments.Add(commentBuilder.MakeComment());
        }
    }
