    internal interface IServiceAInternal
    {
        ServiceResponse ProcessFromServiceB(ServiceRequest request);
    }
    
    public class ServiceA : IServiceA, IServiceAInternal
    {
        public ServiceResponse Process(ServiceRequest request)
        {
            return ProcessCore(request, false);
        }
        
        ServiceResponse IServiceAInternal.ProcessFromServiceB(ServiceRequest request)
        {
            return ProcessCore(request, true);
        }
        
        private ServiceResponse ProcessCore(ServiceRequest request, bool calledFromServiceB)
        {
            ...
        }
    }
    
    public class ServiceB : IServiceB
    {
        private readonly IServiceAInternal _serviceA;
        
        public ServiceB()
        {
            _serviceA = Container.Get<IServiceAInternal>();
        }
        
        public ServiceResponse ReProcess(ServiceRequest request)
        {
            return _serviceA.ProcessFromServiceB(request);
        }
    }
