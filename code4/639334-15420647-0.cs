    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        /* and more fields here */
        public virtual UserProfile UserProfile { get; set; }
    }
