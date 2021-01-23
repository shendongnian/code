    using System;
    
    namespace ProgramConsole
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Person person = new Person();
                // Output: Hello, my name is Soner and I am 24 years old.
                person.setName("Soner").setAge(24).introduce();
            }
        }
    
        class Person
        {
            private String name;
            private int age;
    
            public Person setName(String name)
            {
                this.name = name;
                return this;
            }
    
            public Person setAge(int age)
            {
                this.age = age;
                return this;
            }
    
            public void introduce() {
                    Console.WriteLine("Hello, my name is " + name + " and I am " + age + " years old.");
            }
        }
    }
