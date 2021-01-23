    ClientServices.AddClientService(new ClientService(typeof(IYourService));
    public static class ClientServices
    {
        private static readonly Dictionary<Type, ClientService> _clientServices;
        static ClientServices()
        {
            _clientServices = new Dictionary<Type, ClientService>();
        }
        public static void AddClientService(ClientService clientService)
        {
            if (!_clientServices.ContainsKey(clientService.ContractType))
            {
                _clientServices.Add(clientService.ContractType, clientService);
            }
        }
        public static ClientService GetClientServiceBy(Type contract)
        {
            if (_clientServices.ContainsKey(contract))
            {
                return _clientServices[contract];
            }
            throw new ArgumentException(string.Format("The contract's Type {0} is not registered. Please register the client's endpoint.", contract));
        }
    }
