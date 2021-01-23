    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton()
        {
        }
        private Singleton()
        {
        }
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
        private static readonly Lazy<IPersonManager> _person = 
           new Lazy<IPersonManager>(() => new PersonManager(Instance._adUserName, Instance._adPassword, Instance.client));
        private object _adUserName;
        private object _adPassword;
        private object client;
        public static IPersonManager Person { get { return _person.Value; } }
    }
    public class PersonManager:IPersonManager {}
    public interface IPersonManager{}
