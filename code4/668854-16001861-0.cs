    using System;
    using System.Timers;
    
    public class HelloWorld
    {
        static int a = 0, x = 0, b = 100;
        static Timer timerOut, timerCheck;
    
        static public void Main()
        {
            timerOut = new Timer(3000);
            timerOut.Elapsed += new ElapsedEventHandler(OnOutElapsed);
            timerCheck = new Timer(500); 
            timerCheck.Elapsed += new ElapsedEventHandler(OnCheckElapsed);
            timerCheck.Start();
    
            for(;;) {
                Console.WriteLine("Input x or (Q)uit");
                string s = Console.ReadLine();
                if(s.ToLower() == "q") break;
                x = Convert.ToInt32(s);
            }
        }
    
        private static void OnCheckElapsed(object sender, ElapsedEventArgs e)
        {
            if((Math.Abs(x-a) < 150) && (Math.Abs(x-b) < 150)) {
                if(!timerOut.Enabled) {
                    Console.WriteLine("starting timer (x={0})",x);
                    timerOut.Start(); 
                }
            }
            else if((Math.Abs(x-a) > 150) && (Math.Abs(x-b) > 150)) {
                if(timerOut.Enabled) {
                    Console.WriteLine("stopping timer (x={0})",x);
                    timerOut.Stop();
                }
            }
        }
    
        private static void OnOutElapsed(object sender, ElapsedEventArgs e) 
        {
            Console.WriteLine("write to com port");
        }
    }
