    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();
            myClass.DoWork();
            Console.ReadKey();
        }
    }
    public static class ObjectThreadExtension
    {
        public static void OnThread(this object @object, Action action)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                action();
            });
        }
        public static void OnThread<T>(this object @object, Action<T> action, T argument)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                action(argument);
            });
        }
    }
    public class MyClass
    {
        private void MyMethod()
        {
            Console.WriteLine("I could have been put on a thread if you like.");
        }
        private void MySecondMethod(string argument)
        {
            Console.WriteLine(argument);
        }
        public void DoWork()
        {
            this.OnThread(MyMethod);
            this.OnThread(MySecondMethod, "My argument");
        }
    }
