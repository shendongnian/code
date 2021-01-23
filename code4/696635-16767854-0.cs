    using System;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var wsh = new WebServiceHost(typeof(AService), new Uri("http://0.0.0.0/AService"));
                wsh.Open();
                Console.ReadLine();
            }
            [ServiceContract]
            public class AService
            {
                [OperationContract, WebGet]
                public int AMethod(int i,int j)
                {
                    return i + j;
                }
            }
        }
    }
