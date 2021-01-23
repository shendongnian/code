    [ServiceContract(Session=true)]
    public interface IMyAPI
    {
    ...
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)] 
    public class MyAPI : IMyAPI
    {
    ...
    }
