    public class Project 
    { 
       public ICollection<ProjectCommentEntry> Comments{get;set;}
    }
    public class Sample
    { 
       public ICollection<SampleCommentEntry> Comments{get;set;}
    }
    public class ProjectCommentEntry : CommentEntry {}
    public class SampleCommentEntry : CommentEntry {}
    public class CommentEntry
    { 
       public int Id {get;set;}
       public int CommentEntryId{get;set;}
       public DateTime TimeStamp{get;set;}
       public string Comment{get;set;}
    }
