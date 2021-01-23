    using System;
    
    class Program
    {
        static void Main()
        {
            NetworkClient net = new NetworkClient();
            var sky = (SkyfilterClient)net;
        }
    }
    
    public class NetworkClient{}
    public class SkyfilterClient : NetworkClient{}
