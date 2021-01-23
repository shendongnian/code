    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    
    namespace WCFClientInspector
    {
        public class OperationLogger : IParameterInspector
        {
            public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
            {
                Console.WriteLine("Completed operation:" + operationName);
            }
    
            public object BeforeCall(string operationName, object[] inputs)
            {
                Console.WriteLine("Calling operation:" + operationName);
                return null;
            }
        }
    
        public class OperationLoggerEndpointBehavior : IEndpointBehavior
        {
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
    
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                foreach (ClientOperation operation in clientRuntime.ClientOperations)
                {
                    operation.ClientParameterInspectors.Add(new OperationLogger());
                }
            }
    
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
            }
    
            public void Validate(ServiceEndpoint endpoint)
            {
            }
        }
    
    
        [ServiceContract]
        public interface ISimple
        {
            [OperationContract]
            void DoSomthing(string s);
        }
    
        public class SimpleService : ISimple
        {
            public void DoSomthing(string s)
            {
                Console.WriteLine("Called:" + s);
            }
        }
    
        public static class AttributesAndContext
        {
            static void Main(string[] args)
            {
                ServiceHost simpleHost = new ServiceHost(typeof(SimpleService), new Uri("http://localhost/Simple"));
                simpleHost.Open();
    
                ChannelFactory<ISimple> factory = new ChannelFactory<ISimple>(simpleHost.Description.Endpoints[0]);
                factory.Endpoint.EndpointBehaviors.Add(new OperationLoggerEndpointBehavior());
                ISimple proxy = factory.CreateChannel();
    
                proxy.DoSomthing("hi");
    
                Console.WriteLine("Press ENTER to close the host.");
                Console.ReadLine();
    
                ((ICommunicationObject)proxy).Shutdown();
    
                simpleHost.Shutdown();
            }
        }
    
        public static class Extensions
        {
            static public void Shutdown(this ICommunicationObject obj)
            {
                try
                {
                    obj.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Shutdown exception: {0}", ex.Message);
                    obj.Abort();
                }
            }
        }
    }
