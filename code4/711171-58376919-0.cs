    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
    public class Category : BaseEntity
    {
        public string Name { get; set; }
    }
    public class Status : BaseEntity
    {
        public string Name { get; set; }
    }
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Active { get; set; }
    }
    public class TodoItem : BaseEntity
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public Status Status { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public DateTime CreatedOn { get; set; }
    }
