    public class Departman {
        private readonly Person person = new Person();
        public Person Person { get { return person; } }
    }
    public class Person {
        public string Name {get;set;}
    }
