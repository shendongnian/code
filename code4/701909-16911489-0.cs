    class Program
    {
        public event EventHandler DemoEvent
        {
            add
            {
                demoEvent += value;
            }
            remove
            {
                demoEvent -= value;
            }
        }
        private event EventHandler demoEvent;
        static void Main(string[] args)
        {
            Program p = new Program(); 
            p.DemoEvent += new EventHandler(Program_DemoEvent);
            var list = p.demoEvent.GetInvocationList();
            EventInfo demoEventType = typeof(Program).GetEvent("DemoEvent", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach(var handler in list)
                demoEventType.RemoveEventHandler(p, handler);
        }
        static void Program_DemoEvent(object sender, EventArgs e)
        {
            
        }
    }
