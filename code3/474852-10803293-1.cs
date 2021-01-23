    public interface IReadModel<out T>
    {
        T Data {get;}
    }
    public interface IWriteModel<in T>
    {
        T Data { set; }
    }
    public class SecureModel<T> : IReadModel<T>, IWriteModel<T>
    {
        public string Info { get; set; }
        public T Data { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var m = new SecureModel<string>();
            m.Data = "test";
            IReadModel<object> genericRead = (IReadModel<object>)m;
            Console.WriteLine(genericRead.Data);
        }
    }
