    public class CommentsModel
    {
         Public Int64 CommentId {get;set;}
         ....
         ....
         //Introduce a new property in it as:
         Public CommentsModel[] ChildComments {get;set;}
    }
