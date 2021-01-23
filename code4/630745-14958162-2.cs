    using System.Runtime.Serialization;
    using System.ServiceModel;
    
    namespace WcfService2
    {
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            string GetData(InputData value);
        }
    
        [DataContract]
        public class InputData
        {
            [DataMember]
            public int[] Array { get; set; }
            [DataMember]
            public D SomeStuff { get; set; }
        }
    
        [DataContract]
        public class D
        {
            [DataMember]
            public int Id { get; set; }
        }
    }
    
    using System;
    
    namespace WcfService2
    {
        public class Service1 : IService1
        {
            public string GetData(InputData data)
            {
                if (data.Array == null || data.SomeStuff == null)
                    throw new NullReferenceException();
                return "OK!";
            }
        }
    }
    using ConsoleApplication9.ServiceReference;
    using System;
    
    namespace ConsoleApplication9
    {
        class Program
        {
            static void Main(string[] args)
            {
                var proxy = new Service1Client();
                var request = new InputData
                    {
                        Array = new int[] {1, 2, 3},
                        SomeStuff = new D {Id = 42}
                    };
                Console.WriteLine(proxy.GetData(request));
                Console.ReadKey();
            }
        }
    }
