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
      public class Person : INotifyPropertyChanged
      {
        public event PropertyChangedEventHandler PropertyChanged; 
    
        private string _firstName;
        public string FirstName {
          get
          {
            return _firstName;
          }
          set
          {
            _firstName = value;
            if (PropertyChanged != null)
            {
              PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
          }
        }
    
        private string _lastName;
        public string LastName 
        {
          get
          {
            return _lastName;
          }
          set
          {
            _lastName = value;
            if (PropertyChanged != null)
            {
              PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
          }
        }
    
      }
