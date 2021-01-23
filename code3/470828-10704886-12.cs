    namespace ConsoleApplication61
    {
        class Program
        {
            static void Main(string[] args)
            {
                var f = new Foo();
                f.MyEvent += new EventHandler(Handler);
                f.Trigger();
                f.MyEvent -= new EventHandler(Handler);
                f.Trigger();
                Console.Read();
            }
    
            static void Handler(object sender, EventArgs e)
            {
                Console.WriteLine("handled");
            }
        }
    
        class Foo
        {
            public event EventHandler MyEvent;
            public void Trigger()
            {
                if (MyEvent != null)
                    MyEvent(null, null);
            }
        }
    }
