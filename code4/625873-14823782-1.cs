    public class ServerStatusHelperClass : ObservableObject
    {
        private bool _serverStatus;
        public bool ServerStatus
        {
            get
            {
                return _serverStatus;
            }
            set
            {
                _serverStatus = value;
                RaisePropertyChanged("ServerStatus");
            }
        }
    ...
