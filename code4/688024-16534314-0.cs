    using System;
    
    class Program
    {
        static void Main()
        {
            NetworkClient net = new SkyfilterClient();
            var sky = (SkyfilterClient)net;
        }
    }
    
    public class NetworkClient{}
    public class SkyfilterClient : NetworkClient{}
