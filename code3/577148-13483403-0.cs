    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    namespace Threading
    {
        class Program
        {
        static bool leaderGO = false;
        static bool followerGo = false;
        void Leader()
        {
            do
            {
                lock (this)
                {
                    //Console.WriteLine("? {0}", leaderGO);
                    if (leaderGO) Monitor.Wait(this);
                    Console.WriteLine("> One!");
                    Thread.Sleep(200);
                    leaderGO = true;
                    followerGo = true;
                    Monitor.Pulse(this);
                }
            } while (true);
        }
        void Follower(char chant)
        {
            do
            {
                lock (this)
                {
                    //Console.WriteLine("! {0}", leaderGO);
                    if (!leaderGO) Monitor.Wait(this);
                    if(followerGo)
                    {
                        followerGo = false;
                        Console.WriteLine("{0} Two!", chant);
                        leaderGO = false;
                    }
                    
                    Monitor.Pulse(this);
                }
            } while (true);
        }
        static void Main()
        {
            Console.WriteLine("Go!\n");
            Program m = new Program();
            Thread king = new Thread(() => m.Leader());
            Thread minion1 = new Thread(() => m.Follower('#'));
            Thread minion2 = new Thread(() => m.Follower('$'));
            king.Start();
            minion1.Start();
            minion2.Start();
            Console.ReadKey();
            king.Abort();
            minion1.Abort();
            minion2.Abort();
        }
    }
}
