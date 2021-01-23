    private ReadOnlyCollection<IPAddress> _servers;
    public ReadOnlyCollection<IPAddress> Servers { 
        get {
            lock(_servers) {
                return new ReadOnlyCollection<IPAddress>(_servers);
            }
        }
        private set {
            lock(_servers) {
                _servers = value;
            }
        }
    }
