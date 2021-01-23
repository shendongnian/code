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
           //I HIGHLY recommend you initialize _adusername, 
           //_adpassword and client here.
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
        public static IPersonManager Person { get { return _person.Value; } }
        private object _adUserName;
        private object _adPassword;
        private object client;
    }
    public class PersonManager:IPersonManager {}
    public interface IPersonManager{}
