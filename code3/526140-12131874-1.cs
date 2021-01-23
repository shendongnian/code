    public class MyClass<T>
    {
        public delegate void ActionDelegate(T arg);
        public void RunGenericAction(T arg)
        {
            var actionType = typeof(Action<>).MakeGenericType(typeof(T));
            var constructor = actionType.GetConstructors()[0];
            Delegate @delegate = new ActionDelegate((a) => { Console.WriteLine(arg); });
            var inst = constructor.Invoke(new object[] { @delegate.Target,  @delegate.Method.MethodHandle.GetFunctionPointer() });
            inst(arg);
        }
    }
