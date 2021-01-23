    public interface IReadModel<out T>
    {
        T GetData();
    }
    public interface IWriteModel<in T>
    {
        void SetData(T data);
    }
    public class SecureModel<T> : IReadModel<T>, IWriteModel<T>
    {
        public string Info { get; set; }
        
        public T Data { get; set; }
        public void SetData(T data)
        {
            Data = data;
        }
        public T GetData()
        {
            return Data;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var m = new SecureModel<string>();
            m.Data = "test";
            IReadModel<object> genericRead = (IReadModel<object>)m;
            Console.WriteLine(genericRead.GetData());
        }
    }
