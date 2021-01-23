    public interface IData
    {
        public byte[] Serialize<T>(T obj);
        public T Deserialize<T>(byte[] Data);
    }
    public static class Serializer
    {
        public static byte[] Serialize<T>(T Obj) where T : IData;
        public static T Deserialize<T>(byte[] data) where T : IData, new()
        {
            T res=new T();
            res.Deserialize<T>(data);
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Serializer.Deserialize<Dummy>(new byte[20]);
        }
    }
    class Dummy : IData
    {
    }
