    public interface IDataCommand
    {
        ILogger Logger { get; set; }
    }
    public class Logger : ILogger
    {
        public string Name { get; set; }
    }
    public class FetchDataCommand : IDataCommand
    {
        public ILogger Logger { get; set; }
    }
    public class StoreDataCommand : IDataCommand
    {
        public ILogger Logger { get; set; }
    }
