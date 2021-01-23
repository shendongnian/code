    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        ...
        public virtual ICollection<Person> Persons { get; set; }
    }
    public class Person
    {
        public int PersonId { get; set; }
        public int CreatorId { get; set; } 
        public int RoleId { get; set; } 
        ...
        public virtual Role Role { get; set; }
        public virtual Person Creator { get; set; }
        public virtual ICollection<Person> Created { get; set; }
    }
