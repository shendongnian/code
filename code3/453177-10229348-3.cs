    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IMyAPI
    {
    ...
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)] 
    public class MyAPI : IMyAPI
    {
    ...
    }
