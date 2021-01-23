    public interface INetwork
    {
        DateTime? Date { get; }
    }
    public class PrivateNetworkAbstrctor
        :INetwork
    {
        private PrivateNetwork network;
        public PrivateNetworkAbstrctor(PrivateNetwork network)
        {
            this.network = network;
        }
        public DateTime? Date
        {
            get { return network.DateCreation; }
        }
    }
    public class NetworkingAbstrctor
        : INetwork
    {
        private Networking networking;
        public NetworkingAbstrctor(Networking networking)
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
        networks.AddRange(generalNetWorks.Select(n => new NetworkingAbstrctor(n)));
        networks.AddRange(privateNetWorks.Select(n => new PrivateNetworkAbstrctor(n)));
            
        return networks.OrderBy( n=> n.Date);
    }
