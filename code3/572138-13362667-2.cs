    public interface INetwork
    {
        DateTime? Date { get; }
    }
    public class PrivateNetworkAbstractor
        :INetwork
    {
        private PrivateNetwork network;
        public PrivateNetworkAbstractor(PrivateNetwork network)
        {
            this.network = network;
        }
        public DateTime? Date
        {
            get { return network.DateCreation; }
        }
    }
    public class NetworkingAbstractor
        : INetwork
    {
        private Networking networking;
        public NetworkingAbstractor(Networking networking)
        {
            this.networking = networking;
        }
        public DateTime? Date
        {
            get { return networking.NetWorkingDate; }
        }
    }
    ...
    public IEnumerable<INetwork> MergenSort(IEnumerable<Networking> generalNetWorks, IEnumerable<PrivateNetwork> privateNetWorks)
    {
        var networks = new List<INetwork>();
        networks.AddRange(generalNetWorks.Select(n => new NetworkingAbstractor(n)));
        networks.AddRange(privateNetWorks.Select(n => new PrivateNetworkAbstractor(n)));
            
        return networks.OrderBy( n=> n.Date);
    }
