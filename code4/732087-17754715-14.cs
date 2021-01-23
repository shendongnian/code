    public class ViewModel {
        // WPF will automatically read these properties using reflection.
        public List<Person> People {
            get {
                return new List<Person> {
                    new Person("Sam", "Smith"),
                    new Person("Jim", "Henson"),
                    new Person("Betty", "White")
                };
            }
        }
    }
