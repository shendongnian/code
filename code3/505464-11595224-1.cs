    public class MyCrazySerializer : ISerializer
    {
        public IMyCrazyDataResult Serialize<T>(T instance)
        {
            throw new NotImplementedException();
        }
    
        IDataResult ISerializer.Serialize<T>(T instance)
        {
            return this.Serialize(instance);
        }
    }
