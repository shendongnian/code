    public class SomeEntity
    {
        public int Id { get; set; }
    }
    public class SomeEntityA : SomeEntity
    {
        public int Number { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
    public class SomeEntityB : SomeEntity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public int Username { get; set; }
        public virtual ICollection<SomeEntityA> SomeEntitiesA { get; set; }
        public virtual ICollection<SomeEntityB> SomeEntitiesB { get; set; }
    }
