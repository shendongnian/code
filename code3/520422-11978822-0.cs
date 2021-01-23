    public class PersonView : ObservableCollection<Person>
    {
        public PersonView()
        {
            Add(new Person() { Name = "Luis" });
            Add(new Person() { Name = "Gusth" });
        }
    }
