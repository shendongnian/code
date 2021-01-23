        static void Main(string[] args)
        {
            var wait = new ListenerWaiting(5);
            wait.ListenerDone += WaitListenerDone;
            wait.Listen(3);
      
            Console.ReadLine();
        }
        static void WaitListenerDone(object sender, string e)
        {
            Console.WriteLine(e);
        }
