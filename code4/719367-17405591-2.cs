    // First progressive interface
    public interface ICommentBuilder
    {
        ICommentBuilderPostBy PostWasMadeNow();
        ICommentBuilderPostBy PostWasMadeSpecificallyAt(DateTime postedAt);
    }
    // Second progressive interface
    public interface ICommentBuilderPostBy
    {
        ICommentBuilderPostMessage By(string postedBy);
    }
    // Third progressive interfacve
    public interface ICommentBuilderPostMessage
    {
        ICommentBuilderFinalization About(string message);
    }
    // Final
    public interface ICommentBuilderFinalization
    {
        Comment MakeComment();
    }
    // implementation of the various interfaces
    public class CommentBuilder : ICommentBuilder, ICommentBuilderPostBy, ICommentBuilderPostMessage, ICommentBuilderFinalization
    {
        private Comment InnerComment = new Comment();
        public Comment MakeComment()
        {
            return InnerComment;
        }
        public ICommentBuilderFinalization About(string message)
        {
            InnerComment.Text = message;
            return this;
        }
        public ICommentBuilderPostMessage By(string postedBy)
        {
            InnerComment.PostedBy = postedBy;
            return this;
        }
        public ICommentBuilderPostBy PostWasMadeNow()
        {
            InnerComment.PostedAt = DateTime.Now;
            return this;
        }
        public ICommentBuilderPostBy PostWasMadeSpecificallyAt(DateTime postedAt)
        {
            InnerComment.PostedAt = postedAt;
            return this;
        }
    }
