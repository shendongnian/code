    public class Foo
    {
        // Fixed "forever" or until you manually change it
        public const String ExtensionKey = "3c88c196-06ec-4a89-bffa-6f3fd221f425";
    
        // You will get a new GUID per each Application Domain and per each run
        public static String ExtensionKey1 = Guid.NewGuid().ToString();
        // By convention this shall be private 
        // You will get a new GUID per each instance of a class,
        // but you won't be able to change it
        public readonly String ExtensionKey3 = Guid.NewGuid().ToString();
    }
