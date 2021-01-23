    public class Test
    {
        public event EventHandler AnEvent;
        public Test()
        {
            AnEvent += WhoDoneIt;
        }
        public void Trigger()
        {
            if (AnEvent != null)
                AnEvent(this, EventArgs.Empty);
        }
        public void WhoDoneIt(object sender, EventArgs eventArgs)
        {
            var stack = new StackTrace();
            for (var i = 0; i < stack.FrameCount; i++)
            {
                var frame = stack.GetFrame(i);
                var method = frame.GetMethod();
                Console.WriteLine("{0}:{1}.{2}", i, method.DeclaringType.FullName, method.Name);
            }
        }    
    }
    public class Program 
    {
        static void Main(string[] args)
        {
            var test = new Test();
            test.Trigger();
            Console.ReadLine();
        }
    }
