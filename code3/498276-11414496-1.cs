    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person {Name ="John", BaseCode="AA12", Locations = new List<Location>
            {
                new Location { Name = "India" },
                new Location { Name = "USA" }
            }};
            var p2 = new Person {Name ="John", BaseCode="AA13", Locations = new List<Location>
            {
                new Location { Name = "India" },
                new Location { Name = "USA" }
            }};
            var p3 = new Person {Name ="John", BaseCode="AA14", Locations = new List<Location>
            {
                new Location { Name = "India" },
                new Location { Name = "UK" }
            }};
            var persons = new List<Person> { p1, p2, p3 };
            // Will not return p2.
            var distinctPersons = persons.Distinct(new PersonComparer()).ToList();
            Console.ReadLine();
        }
    }
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (x == null || y == null)
                return false;
            bool samePerson = x.Name == y.Name;
            bool sameLocations = !x.Locations
                .Except(y.Locations, new LocationComparer())
                .Any();
            return samePerson && sameLocations;
        }
        public int GetHashCode(Person obj)
        {
            return obj.Name.GetHashCode();
        }
    }
    public class LocationComparer : IEqualityComparer<Location>
    {
        public bool Equals(Location x, Location y)
        {
            if (x == null || y == null)
                return false;
            return x.Name == y.Name;
        }
        public int GetHashCode(Location obj)
        {
            return obj.Name.GetHashCode();
        }
    }
