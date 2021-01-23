    public class MyClass<T>
    {
        public delegate void ActionDelegate(T arg);
        void doAction(T arg)
        {
            Console.WriteLine(arg);    
        }
        public void RunGenericAction(T arg)
        {
            var actionType = typeof(Action<>).MakeGenericType(typeof(T));
            var constructor = actionType.GetConstructors()[0];
            Delegate @delegate = new ActionDelegate(doAction);
            constructor.Invoke(@delegate, null);
        }
    }
