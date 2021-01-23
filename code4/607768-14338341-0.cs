    public class EntityWithNotes
    {
      public int Id { get; set; }
      public string Title { get; set; }
      public Collection<Note> { get; set; }
    }
    
    public class Note
    {
      public int Id { get; set; }
      public string Description { get; set; }
      public int ParentId { get; set; }
    }
    
    public class Case : EntityWithNotes { /* ...*/ }
    public class Task : EntityWithNotes { /* ...*/ }
