    public class PersonViewModel : *INotifyPropertyChanged base class here*
    {
        public PersonViewModel()
        {
            UpdatePersonCommand = new RelayCommand(UpdateUser);
        }
        public Guid Id {get{ return _id;} { set _id = Id; RaisePropertyChanged("Id"); }
        public string FirstName { ... same }
        public string LastName { ... same }
        
        public ICommand UpdatePersonCommand {get; private set;}
        private void UpdateUser()
        {
            UpdateUser(Id, FirstName, LastName);
        }
        private void UpdateUser(Guid Id, string FirstName, string LastName)
        {
            DatabaseDataContext DC = new DatabaseDatacontext();
            ...
        }
    }
