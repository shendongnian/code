    public class MainClass
    {
        private delegate void MethodDelegate();
        private List<MethodDelegate> delegates_ = new List<MethodDelegate>();
        // ctor
        public MainClass()
        {
            delegates_.Add(Class2.Method2);
            delegates_.Add(Class3.Method3);
            delegates_.Add(Class4.Method4);
        }
        // Call a method
        public void Method1()
        {
            // decide what you want to call:
            delegates_[0].Invoke(); // "Class2.Method2"
        } // eo Method1
    }  // eo class Main
