    namespace DataGridTest
    {
      using System.Collections.ObjectModel;
      using System.ComponentModel;
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<Person> _persons = new ObservableCollection<Person>();
        private static int _id = 3;
        public ObservableCollection<Person> Persons
        {
            get
            {
                return _persons;
            }
        }
        public MainWindowViewModel()
        {
            _persons.Add(new Person { Id = 1, Name = "A" });
            _persons.Add(new Person { Id = 2, Name = "B" });
            _persons.Add(new Person { Id = 3, Name = "C" });  
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void Refresh()
        {
            _persons.Add(new Person() { Id = ++_id, Name = _id.ToString() });
        }
    }
   }
