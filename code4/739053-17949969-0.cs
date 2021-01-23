    public interface ITaskScheduleAlgorithm<TType>
    {
    }
        
    public class SimpleTaskScheduleAlgorithm<TType> : ITaskScheduleAlgorithm<TType>
    {
    }
    
    public ITaskScheduleAlgorithm<object> GetAlgorithm()
    {
        return new SimpleTaskScheduleAlgorithm<string>();
    }
