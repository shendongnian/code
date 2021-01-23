    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IService1
    {
        public string SessionId()
        {
            return OperationContext.Current.SessionId;
        }
    }
