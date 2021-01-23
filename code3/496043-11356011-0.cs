    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Timers;
    namespace ConsoleApplication1
    {
       class Program
     {
        TimeSpan tt;
        static void Main(string[] args)
        {
            Program p = new Program();
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(p.run));
            t.Start();
            while (true) ;
        }
        void run()
        {
            tt=new TimeSpan(0,1,0);
            //Timer interval decides when even will be fired.
            Timer t = new Timer(60000);
            t.AutoReset = true;
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.Start();
            
        }
        public void t_Elapsed(object sender, EventArgs e)
        {
            
            if (tt.Minutes % 5 == 0)
                Console.WriteLine("Break");
            Console.WriteLine(tt.Hours.ToString()+":"+tt.Minutes.ToString());
            tt = tt.Add(new TimeSpan(0, 1, 0));
        }
    }
    }
