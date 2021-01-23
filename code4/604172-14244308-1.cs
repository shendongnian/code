     public abstract class Vote
     {
        public int VoteID { get; set; }
        public bool isVote { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; } 
    
        public int VoteType { get; set;} //this property specifies type of vote (e.g. VoteType=1 for CommentedVote )
     } 
     public class CommentVote : Vote
     {
        public int CommentID { get; set; }  
        public virtual Comment Comment { get; set; }  
     }
     public class OtherVote : Vote
     {
        public int OtherID { get; set; }  
        public virtual Other Other { get; set; }  
     }
