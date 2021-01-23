    public class Foo
    {
        // Fixed "forever" or until you manually change it
        // Cannot be changed in run-time
        public const String ExtensionKey = "3c88c196-06ec-4a89-bffa-6f3fd221f425";
    
        // You will get a new GUID per each Application Domain and per each run
        // Can be changed
        public static String ExtensionKey1 = Guid.NewGuid().ToString();
        // By convention this shall be private, as it's a field
        // You will get a new GUID per each instance of a class,
        // Once assigned, the value cannot be changed
        public readonly String ExtensionKey3 = Guid.NewGuid().ToString();
        // You will get a new GUID per each Application Domain and per each run,
        // Once assigned, the value cannot be changed
        public static readonly String ExtensionKey4 = Guid.NewGuid().ToString();
    }
