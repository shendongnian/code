    public interface ILoggingService
    {
        void WriteToLog(string logMsg);
    }
    public class LoggingService : ILoggingService
    {
        public void WriteToLog(string logMsg)
        {
            ... WriteToLog implementation ...
        }
    }
    public interface ICustomerService
    {
        ... Methods and properties here ...
    }
    public class CustomerService : ICustomerService
    {
        public CustomerService(ILoggingService myServiceInstance)
        { 
            // work with the dependent instance
            myServiceInstance.WriteToLog("SomeValue");
        }
    } 
    ...
    ...
    // Bootstrap the container. This is typically part of your application startup.
    IUnityContainer container = new UnityContainer();
    container.RegisterType<ILoggingService, LoggingService>();
    container.RegisterType<ICustomerService, Customerservice>();
    ...
    ...
    ICustomerService myInstance = container.Resolve<ICustomerService>();
