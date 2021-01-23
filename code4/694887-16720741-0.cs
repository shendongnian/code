    namespace timerconsole
    {
        class MainClass
        {
            static int workOut; /* Here */
            public void run ()
            {
                int width = 35;
                int height = 10;
                Console.SetWindowPosition(0, 0); 
                Console.SetWindowSize(width, height); 
                Console.SetBufferSize(width, height); 
                Console.SetWindowSize(width, height);
                Console.WriteLine ("What time do you leave work today: ");
                String workTime = Console.ReadLine ();
                int.TryParse (workTime, out workOut);
                TimerCallback callback = new TimerCallback(Tick);
                // create a one second timer tick
                Timer stateTimer = new Timer(callback, null, 0, 1000);
                // loop here forever
                for (; ; ) { } /* You may want to use Thread.Sleep to not consume *all* of the CPU */
            }
            static public void Tick(Object stateInfo)
            {
                Console.Clear ();
                Console.WriteLine("The time is: {0}", DateTime.Now.ToString("h:mm:ss") + "\nWork Target: {0}", workOut);
            }
            public static void Main (string[] args)
            {
                MainClass tc = new MainClass ();
                tc.run ();
            }
        }
    }
