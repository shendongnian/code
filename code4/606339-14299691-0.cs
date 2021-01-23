       class Program
    {
        static void Main(string[] args)
        {
            List<KeyValuePair<int, int>> housePersonPairs = new List<KeyValuePair<int, int>>();
            housePersonPairs.Add(new KeyValuePair<int, int>(1, 11));
            housePersonPairs.Add(new KeyValuePair<int, int>(1, 12));
            housePersonPairs.Add(new KeyValuePair<int, int>(1, 13));
            housePersonPairs.Add(new KeyValuePair<int, int>(2, 232));
            housePersonPairs.Add(new KeyValuePair<int, int>(2, 5533));
            housePersonPairs.Add(new KeyValuePair<int, int>(2, 40));
            //personid person name
            List<Person> persons = new List<Person>();
            persons.Add(new Person() { ID = 11, Name = "John" });
            persons.Add(new Person() { ID = 12, Name = "Jane" });
            persons.Add(new Person() { ID = 13, Name = "Zoe" });
            persons.Add(new Person() { ID = 232, Name = "Name1" });
            persons.Add(new Person() { ID = 5533, Name = "Name2" });
            persons.Add(new Person() { ID = 40, Name = "Name3" });
            var houseAndNames = housePersonPairs.Join(
                persons,
                hpp => hpp.Value,
                p => p.ID, 
                (hpp, p) => new { HouseID = hpp.Key, Name = p.Name });
            var groupedNames = from hn in houseAndNames
                         group hn by hn.HouseID into groupOfNames
                         select groupOfNames.Select(x => x.Name).ToList();
            List<House> houses = groupedNames.Select(names => new House() { people_name = names }).ToList();
        }
    }
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class House
    {
        public List<string> people_name { get; set; }
    }
