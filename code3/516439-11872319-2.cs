    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Person
        {
        }
        class City
        {
            // City has citizens:
            Person[] citizens;
            public IEnumerable<Person> People
            {
                get
                {
                    return citizens;
                }
            }
        }
        class State : IEnumerable<Person>, IEnumerable<City>
        {
            // State has cities:
            City[] cities;
            public IEnumerable<City> Cities
            {
                get
                {
                    return cities;
                }
            }
            public IEnumerable<Person> AllPeople
            {
                get
                {
                    return Cities.SelectMany(c => c.People);
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                State s = new State();
                foreach (Person p in s.AllPeople) { /* Do something */ }
                foreach (City c in s.Cities) { /* Do something */ } 
            }
        }
    }
