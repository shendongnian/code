    using System;
    
    class Program
    {
        static void Main()
        {
            NetworkClient net = new NetworkClient();
            var sky = SkyFilterClient.CopyToSkyfilterClient(net);
        }
    }
    
    public class NetworkClient
    {  
      public int SomeVal {get;set;}
    }
    
    public class SkyfilterClient : NetworkClient
    {
        public int NewSomeVal {get;set;}
        public static SkyfilterClient CopyToSkyfilterClient(NetworkClient networkClient)
        {
            return new SkyfilterClient{NewSomeVal = networkClient.SomeVal};
        }
    }
