    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace App
    {
        public enum ID{
            one, two, three, four, five, six, seven, eigth, nine, ten
        }
        public class Person
        {
            public ID id;
            public List<Person> children;
            public Person(ID id, List<Person> children)
            {
                this.id = id;
                this.children = children;
            }
        }
        class Program
        {
            private static List<Person> BuildScenario()
            {
                return new List<Person>{
                    new Person(ID.one, new List<Person>()),
                    new Person(ID.two, new List<Person>{
                        new Person(ID.three, new List<Person>{
                            new Person(ID.ten, new List<Person>())
                        }),
                        new Person(ID.four, new List<Person>())
                    }),
                    new Person(ID.five, new List<Person>{
                        new Person(ID.six, new List<Person>()),
                        new Person(ID.seven, new List<Person>()),
                        new Person(ID.eigth, new List<Person>())
                    })
                };
            }
            static void Main(string[] args)
            {
                List<Person> scenario = BuildScenario();
                Console.WriteLine(CountIDs(scenario).ToString());
                Console.WriteLine(GetMaxID(scenario).ToString());
                while(true);
            }
            private static int CountIDs(List<Person> scenario)
            {
                int count = 0;
                foreach (Person person in scenario)
                {
                    count += 1 + CountIDs(person.children);
                }
                return count;
            }
            private static ID GetMaxID(List<Person> scenario)
            {
                ID maxid = 0;
 	            foreach(Person person in scenario)
                {
                    ID childmax = GetMaxID(person.children);
                    if (person.id > maxid) maxid = person.id;
                    if (childmax > maxid) maxid = childmax;
                    
                }
                return maxid;
            }
        }
    }
