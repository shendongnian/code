    public interface IToken { }
    public class Abc : IToken { }
    public class Xyz : IToken { }
    public class Num : IToken { }
    public interface ISingletonFactory<out T> where T : IToken
    {
        T Produce(int position);
        T Produce(int position, string token);
    }
    public class SingletonFactory<T> : ISingletonFactory<T> where T : IToken
    {
        private SingletonFactory() { }
        private static SingletonFactory<T> _instance = new SingletonFactory<T>();
        public static SingletonFactory<T> Instance { get { return _instance; } }
        public T Produce(int position) { return (T)Activator.CreateInstance(typeof(T), position); }
        public T Produce(int position, string token) { return (T)Activator.CreateInstance(typeof(T), position, token); }
    }
    var keywords = new Dictionary<string, ISingletonFactory<IToken>>()
    {
        { "abc", SingletonFactory<Abc>.Instance },
        { "xyz", SingletonFactory<Xyz>.Instance },
        { "123", SingletonFactory<Num>.Instance }
    };
