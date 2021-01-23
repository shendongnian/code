    public class Parent
    {
        public string Name { get; set; }
        public string City { get; set; }
        public Parent(string name, string city)
        {
            this.Name = name;
            this.City = city;
        }
        public Parent():this(string.Empty, string.Empty)
        {
        }
    }
    public class Child : Parent
    {
        public Child(Parent parent, int age):base(parent.Name, parent.City)
        {
            this.Age = age;
        }
        public int Age { get; set; }
    }
