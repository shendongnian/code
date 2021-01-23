    class Program
    {
        static Type[] parmTypes;
        static void Main(string[] args)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Dll1.dll");
            Assembly asm = Assembly.LoadFile(path);
            Type typ = asm.GetType("DLL1.Class1", true, true);
            var method = typ.GetMethod("add");
            EventInfo eInfo = typ.GetEvents()[0];
            var obj = Activator.CreateInstance(typ);
            EventProcessor evProc = new EventProcessor();
            //Type delegateType = asm.GetType("Dll1.Class1+AddHandler", true, true);
            Type delegateType = typeof(EventHandler<int>);
            MethodInfo myMethodInfo = typeof(EventProcessor).GetMethod("myEventHandler");
            Delegate d = Delegate.CreateDelegate(delegateType, evProc, myMethodInfo); // Add evProc as the target parameter since you are using an instance method.
            eInfo.AddEventHandler(obj, d);
            method.Invoke(obj, new object[] { 1, 0 });
        }
    }
    class EventProcessor
    {
        public void myEventHandler(object sender, int args)
        {
            Console.WriteLine("Event Received: " + args);
        }
    }
