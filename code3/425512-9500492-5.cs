    public class MyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> People { get; set; }
    
        public MyViewModel()
        {
            this.People = new ObservableCollection<Person>();
            this.LoadPeople();
        }
    
        private void LoadPeople()
        {
            this.People.Clear();
            // Have your logic here that loads the people collection
        }
    }
