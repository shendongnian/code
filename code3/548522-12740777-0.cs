    public class Person 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Person> FriendWith { get; set; } 
        public virtual ICollection<Person> FriendOf { get; set; } 
    }
