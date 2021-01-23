    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    
    namespace WcfHost
    {
        [ServiceContract(Namespace="http://www.zzz.com/ema/xml/")]
        public interface IAsmbServiceSoap
        {
            [OperationContract]
            void Login(string url, string id, int ClientType, out int ClientID); 
        }
    
        public class AService : IAsmbServiceSoap
        {
            #region IAsmbServiceSoap Members
    
            public void Login(string url, string id, int ClientType, out int ClientID) {
                ClientID = 100;
                // do work
            }
    
            #endregion
        }
    
    
        class Program
        {
            static void Main(string[] args) {
    
                ServiceHost serviceHost = new ServiceHost(typeof(AService), new Uri("http://localhost:8000/AService"));
    
                ServiceMetadataBehavior metadataBehavior = new ServiceMetadataBehavior() { HttpGetEnabled = true };
                serviceHost.Description.Behaviors.Add(metadataBehavior);
    
                serviceHost.Open();
    
                Console.WriteLine("Open for communication.  Press ENTER to close.");
                Console.ReadLine();
    
                serviceHost.Close();
            }
        }
    }
