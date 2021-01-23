    class Program
    {
        private event EventHandler demoEvent;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.demoEvent += new EventHandler(Program_DemoEvent);
            var list = p.demoEvent.GetInvocationList();
            var demoEventType = typeof(Program).GetEvent("demoEvent", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            MulticastDelegate myValue = typeof(Program).GetField("demoEvent", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).GetValue(p) as MulticastDelegate;
            var invocationList = myValue.GetInvocationList();
            foreach (var handler in invocationList)
                demoEventType.RemoveEventHandler(p, handler);
        }
        static void Program_DemoEvent(object sender, EventArgs e)
        {
            
        }
    }
