    public class TestableDerived : DerivedClass {
        public TestableDerived(List<Person> people) {
            this.Persons = people;
        }
        public List<Person> AccessablePersons { get { return this.Persons; } }
    }
