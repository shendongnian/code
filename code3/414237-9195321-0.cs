    // make a public interface
    public interface IPerson {
        String Name { get; }
        String Age { get; }
    }
    public class Manager {
        public IEnumerable<IPerson> GetPeople() {
            var retVal = new List<Person>();
            // Do your retrieval. Here you can access
            // the setters of your class. 
            return retVal;
        }
        // make a private implementation
        private class Person : IPerson {
            public String Name { get; set; }
            public String Age { get; set; }
            // explicit interface implementation
            String IPerson.Name {
                get { return Name; }
            }
            String IPerson.Age {
                get { return Age; }
            }
        }
    }
