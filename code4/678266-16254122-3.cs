    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        public static class Program
        {
            private static void Main()
            {
                dict = new SortedDictionary<string, Person>();
                addPerson("iain", "banks");
                addPerson("peter", "hamilton");
                addPerson("douglas", "adams");
                addPerson("arthur", "clark");
                addPerson("isaac", "asimov");
                Console.WriteLine("--------------");
                foreach (var person in dict)
                    Console.WriteLine(person.Value);
                var list = (from entry in dict
                            orderby entry.Value.LastName
                            select entry.Value).ToList();
                Console.WriteLine("--------------");
            
                foreach (var person in list)
                    Console.WriteLine(person);
            }
            private static void addPerson(string firstname, string lastname)
            {
                dict.Add(firstname, new Person{FirstName = firstname, LastName = lastname});
            }
            private static SortedDictionary<string, Person> dict;
        }
        public class Person
        {
            public string FirstName;
            public string LastName;
            public override string ToString(){return FirstName + " " + LastName;}
        }
    }
