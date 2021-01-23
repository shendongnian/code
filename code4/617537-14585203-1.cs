    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        private static string _StaticMessage = "Type ctor;";
        private string _Message = "init; ";
        static Singleton()
        { }
        private Singleton()
        {
            _Message += "ctor; ";
        }
        public static Singleton Instance
        {
            get { return instance; }
        }
        public string Message { get { return _StaticMessage + _Message; } }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var singleton = Singleton.Instance;
            // writes "Type ctor;init; ctor;"
            Console.WriteLine(singleton.Message);
            var instance = (Singleton)System.Runtime.Serialization.FormatterServices
            .GetSafeUninitializedObject(typeof(Singleton));
            // writes "Type ctor;"
            Console.WriteLine(instance.Message);
        }
    }
