    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace StackDemo
    {
        class Program 
        {
            static void Main(string[] args)
            {
                List<Person> persons = new List<Person>();
                persons.Add(new Person("John",30));
                persons.Add(new Person("Jack", 27));
    
                ICollection<Person> personCollection = persons;
                IEnumerable<Person> personEnumeration = persons;
                
                //IEnumeration
                //IEnumration Contains only GetEnumerator method to get Enumerator and make a looping
                foreach (Person p in personEnumeration)
                {                                   
                   Console.WriteLine("Name:{0}, Age:{1}", p.Name, p.Age);
                }
    
                //ICollection
                //ICollection Add/Remove/Contains/Count/CopyTo
                //ICollection is inherited from IEnumerable
                personCollection.Add(new Person("Tim", 10));
                
                foreach (Person p in personCollection)
                {
                    Console.WriteLine("Name:{0}, Age:{1}", p.Name, p.Age);        
                }
                Console.ReadLine();
    
            }
        }
    
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Person(string name,int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }
    }
