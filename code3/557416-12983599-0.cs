    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual List<Child> Children { get; set; }
        // Your other code
    }
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
