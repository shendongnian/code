    namespace WpfApplication3
    {
        public class Person
        {
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
    
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var persons = new List<Person>
                    {
                        new Person("Steve", "Jobs"),
                        new Person("Bill", "Gates"),
                        new Person("Dan", "Brown"),
                        new Person("Barack", "Obama")
                    };
    
                MyGrid.ItemsSource = persons;
            }
    
            private void Next(object sender, RoutedEventArgs e)
            {
                MyGrid.Focus();
    
                int nextIndex = MyGrid.SelectedIndex + 1;
                if (nextIndex > MyGrid.Items.Count - 1) return;
                MyGrid.SelectedIndex = nextIndex;
            }
    
            private void Previous(object sender, RoutedEventArgs e)
            {
                MyGrid.Focus();
    
                int previousIndex = MyGrid.SelectedIndex - 1;
                if (previousIndex < 0) return;
                MyGrid.SelectedIndex = previousIndex;
            }
        }
    }
