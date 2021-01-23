    public class Factory<T, U>
        where T : Y
        where U : Aaa<T>, new()
    {
        public static IAaa<T> Get()
        {
            return (IAaa<T>)new U();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            IAaa<X> aa;
            aa = Factory<X, Bbb>.Get();
        }
    }
