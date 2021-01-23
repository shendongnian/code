    public class MainViewModel : NotificationObject
    {
        public MainViewModel()
        {
            Person = new Person();
            SaveCommand = new DelegateCommand(SaveExecuted);
        }
        // Properties
        public Person Person { get; set; }
        // Commands
        public ICommand SaveCommand { get; set; }
        private void SaveExecuted()
        {
            // Do some save logic here!
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
