    ServiceHost host = new ServiceHost(
    typeof(MyContract),
    new Uri("http://localhost:8080/MyContract"));
    host.AddServiceEndpoint("IMyContract", new WSHttpBinding(), "");
    System.ServiceModel.Description.ServiceThrottlingBehavior throttlingBehavior =
    new System.ServiceModel.Description.ServiceThrottlingBehavior();
    throttlingBehavior.MaxConcurrentCalls = 16;
    throttlingBehavior.MaxConcurrentInstances = Int32.MaxValue;
    throttlingBehavior.MaxConcurrentSessions = 10;
    host.Description.Behaviors.Add(throttlingBehavior);
    host.Open();
