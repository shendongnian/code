    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                new Program().test();
            }
            void test()
            {
                Insert(new Persons()["John", "Doe"]["Sherlock", "Holmes"]["Fred", "Flintsone"]);
            }
            public void Insert(params Person[] persons)
            {
                foreach (var person in persons)
                {
                    Console.WriteLine(person);
                }
            }
        }
        public class Persons
        {
            public static implicit operator Person[](Persons people)
            {
                return people.people.ToArray();
            }
            public Persons this[string firstName, string lastName]
            {
                get
                {
                    people.Add(new Person(firstName, lastName));
                    return this;
                }
            }
            private readonly List<Person> people = new List<Person>();
        }
        public class Person
        {
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
            public override string ToString()
            {
                return FirstName + " " + LastName;
            }
            public readonly string FirstName, LastName;
        }
    }
