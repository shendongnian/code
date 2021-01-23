    public static ServiceHost OpenServiceHost<T, U>(T instance, string address) 
    {
        ServiceHost host = new ServiceHost(instance, new Uri[] { new Uri(address) });
        ServiceBehaviorAttribute behaviour = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
        behaviour.InstanceContextMode = InstanceContextMode.Single;
        host.AddServiceEndpoint(typeof(U), new NetNamedPipeBinding(), serviceEnd);
        host.Open();
        return host;
    }
