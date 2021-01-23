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
                Insert(new People()["John", "Doe"]["Sherlock", "Holmes"]["Fred", "Flintsone"]);
            }
            public void Insert(params Person[] persons)
            {
                foreach (var person in persons)
                {
                    Console.WriteLine(person);
                }
            }
        }
        public class People
        {
            public static implicit operator Person[](People people)
            {
                return people.people.ToArray();
            }
            public People this[string firstName, string lastName]
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
