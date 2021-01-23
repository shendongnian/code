    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    namespace QueueWorkRunOnce {
    public class Test {
        public static void worker(List<string> collection) {
            Console.WriteLine(string.Join(" ", collection.ToArray()));
        }
        public static List<string> args = new List<string>();
        public Timer timer = new Timer(state => {
            worker(args);
            args.Clear();
        });
        public void queueWorkRunOnce(string arg){
            args.Add(arg);
            timer.Change(/*Delay in ms*/ 1000, Timeout.Infinite);
        }
        public Test() {
            Console.WriteLine("new Test");
            queueWorkRunOnce("Hi");
            //Some other stuff
            queueWorkRunOnce("There");
            //Some other stuff
            queueWorkRunOnce("Hello");
            queueWorkRunOnce("World");           
        }
    }
    class Program {
        static void Main(string[] args) {
            new Test();
            Thread.Sleep(3000);
            new Test();
            Console.ReadKey();
        }
    }
}
