    public class MyClass : IDisposable {
        public IList List1<int> {get; private set;}
        public IDictionary<string,string> Dict1 {get; private set;}
        public void Dispose() {
            // Do something here
        }
        public static MyClass Instance {get; private set;}
        static MyClass() {
            Instance = new MyClass();
        }
        public static void DisposeInstance() {
            if (instance != null) {
                Instance.Dispose();
                Instance = null;
            }
        }
    }
