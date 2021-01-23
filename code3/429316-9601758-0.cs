    public class Person {
        public string Name { get; set; }
        public int Age { get; set; }
    }
     Persons = new ObservableCollection<Person>() {
          new Person() { Name = "John", Age = 30 },
          new Person() { Name = "Tim", Age = 48 }
     };
     lbPersons.DataContext = Persons;
     private void person_Clicked(object sender, RoutedEventArgs e) {
            Button cmd = (Button)sender;
            if (cmd.DataContext is Person) {
                Person p = (Person)cmd.DataContext;
            }
        }
