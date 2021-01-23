      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
          List<Person> list = new List<Person>();
    
          list.Add(new Person() { FirstName = "Firstname", LastName = "Lastname"});
    
          DataContext = list;
    
        }
      }
      public class Person
      {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
      }
