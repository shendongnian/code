    public class NetworkInterface
    {
        public void ConnectTo(NetworkInterface otherInterface)
        {
        }
    }
    ...
    NetworkInterface localhost = new NetworkInterface();
    localhost.ConnectTo(localhost);
