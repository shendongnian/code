    internal static class ServiceObjects
    {
        public static ISomeService SomeSVC { get { return GetSomeServiceClient(); }
        private static BasicHttpBinding _Binding = new BasicHttpBinding("SomeBasicHttpBindingEndpoint"); 
        private static EndpointAddress _Endpoint = new EndpointAddress(new Uri("http://test.helloworld.com/SomeService.svc"));
        private static IDocManagerService GetDocServiceClient()
        {
            ChannelFactory<ISomeService> _someSvcFactory = new ChannelFactory<ISomeService>(_Binding, _Endpoint);
            foreach (OperationDescription op in _someSvcFactory.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior _dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>() as DataContractSerializerOperationBehavior;
                if (_dataContractBehavior != null)
                {
                    _dataContractBehavior.MaxItemsInObjectGraph = int.MaxValue;
                }
            }
            return _someSvcFactory.CreateChannel();
        }
    }
