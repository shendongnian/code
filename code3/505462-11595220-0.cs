    // General purpose
    public interface ISerializer
    {
        IDataResult Serialize<T>(T instance);
    }
    
    // General purpose
    public interface IDataResult
    {
    }
    
    // Specific - and I implement IDataResult
    public interface IMyCrazyDataResult : IDataResult
    {
    }
    
    public class MyCrazySerializer : ISerializer
    {
        public IDataResult Serialize<T>(T instance)
        {
            // return a IMyCrazyDataResult here
        }
    }
