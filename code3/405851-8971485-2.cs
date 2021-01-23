    public class MasterViewModel : INotifyPropertyChanged
    {
        private IEnumerable<ClientViewModel> _clients = new ClientViewModel[] 
        {
            new ClientViewModel() { FirstName = "Dave", LastName = "Cameron" }, 
            new ClientViewModel() { FirstName = "Ed", LastName = "Miliband" }, 
        }
        public IEnumerable<ClientViewModel> Clients
        {
            get { return _clients; } 
        } 
    }
