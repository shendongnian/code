        namespace WcfService1
        {
            [ServiceContract(SessionMode = SessionMode.Required,
                CallbackContract = typeof (IStreamCallback),
                ProtectionLevel = ProtectionLevel.None)]
            public interface IService1
            {
            .....
            [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
            [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
            public 
    
        class Service1 : IService1
        {
