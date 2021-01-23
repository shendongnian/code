    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
    public class Employee : Person
    {
        public string WorkPhone { get; set; }
    }
    public abstract class MyBase<T> where T : Person
    {
        public abstract T Someone { get; set; }
    }
    public class TestClass : MyBase<Employee>
    {
        public override Employee Someone { get; set; } 
    }
    public class TestClass2 : MyBase<Person>
    {
        public override Person Someone { get; set; }
    }
