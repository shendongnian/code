    public class ServiceDependencies
    {
        public string ServiceName {get;set;}
        public List<ServiceDependencies> DependsOn {get;private set;}
    }
