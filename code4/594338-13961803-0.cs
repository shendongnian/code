    public class Person : IEntity
    {
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<PersonSession> Sessions { get; set; }
    }
    
     public class PersonSession : IEntity
     {
		[Key]
		public int Id { get; set; }
		public Person Person { get; set; }
		public Session Session { get; set; }
     }
    
    public class Session : IEntity
    { 
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }     
    }
