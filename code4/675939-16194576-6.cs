    public class MainPageViewModel : BindableBase
    {
        public MainPageViewModel()
        {
        }
        private Person person;
        public Person Person
        {
            get { return person; }
            set { SetProperty(ref person, value); }
        }
        public void LoadData()
        {
            Person = new Person() { Name = "Simple name" };
        }
        public void UpdatePerson()
        {
            Person.Name = "Updated Name";
            OnPropertyChanged("Person");
        }
    }
