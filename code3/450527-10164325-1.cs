    public class MainWindowModel : ObservableObject
    {
        private readonly ObservableCollection<Person> personCollection = new ObservableCollection<Person>()
        {
            new Person() { Name = "Bob", Age = 20 }
        };
    
        public ObservableCollection<Person> PersonCollection
        {
            get { return this.personCollection; }
        }
    }
