    //C++/CLI
    public ref class SomeClass
    {
        public:
        event EventHandler^ someEvent;
    }
    //C#
    class Program
    {
        static void Main(string[] args)
        {
            SomeClass testclass = new SomeClass();
            testclass.someEvent += someEventHandler;
        }
        private void someEventHandler(Object obj, EventArgs args)
        {
  
        }
