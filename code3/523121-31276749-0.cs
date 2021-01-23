    public class Comment {
      public int Id { get; set; }
      public string Body { get; set; }
      public virtual Post Post { get; set; }
      [ForeignKey("Post")]
      public int PostId { get; set; }
    }
