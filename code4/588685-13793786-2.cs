    public class MyEntity {
      private string comments;
      public virtual string Comments { 
        get {return comments;}  
        set {comments = str.Substring(0, Math.Min(value.Length, 255))}; 
       }
    }
