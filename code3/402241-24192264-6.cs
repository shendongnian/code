    public class Person {
        public String fName {get; private set;}
        public Person(String name) {
            this.fName = name;
        }
    }
    public class Example {
        Person person = new Person("Fred");
        Console.WriteLine(person.fName); // This is allowed 
        person.fName = "Tony"; // Not allowed because setter is private
    }
