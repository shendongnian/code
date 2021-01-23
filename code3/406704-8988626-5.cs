      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
          ObservableCollection<Person> list = new ObservableCollection<Person>();
    
          list.Add(new Person() { FirstName = "Firstname", LastName = "Lastname"});
    
          DataContext = list;
    
        }
      }
      public class Person
      {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
      }
