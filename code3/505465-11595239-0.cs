    // General purpose
    public interface ISerializer<out TResult> where TResult : IDataResult
    {
        TResult Serialize<T>(T instance);
    }
    // General purpose
    public interface IDataResult
    {
    }
    // Specific - and I implement IDataResult
    public interface IMyCrazyDataResult : IDataResult
    {
    }
    public class MyCrazySerializer : ISerializer<IMyCrazyDataResult>
    {
        public IMyCrazyDataResult Serialize<T>(T instance)
        {
            throw new NotImplementedException();
        }
    }
