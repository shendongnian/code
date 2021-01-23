    public class YourPageViewModel : INotifyPropertyChanged
    {
        public List<Model.Person> People { get; set; }
        private Model.Person _selectedPerson;
        public Model.Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                if (_selectedPerson != value)
                {
                    _selectedPerson = value;
                    PropertyChangedEventHandler handler = this.PropertyChanged;
                    if (handler != null)
                        handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
