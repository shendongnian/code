    public interface ICommentable {
     // basically a marker interface like Serializable
    }
    public class Picture : ICommentable {
     // etc
    }
    public class Comment {
     // etc
     public ICommentable _commentAttachedTo;
    }
