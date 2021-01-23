    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          var iResult = new List<Task>();
          for (int i=5; i>2; i--)
          {
            int load = i;
            var task = Task.Factory.StartNew(() =>
                            DoSomething(load), TaskCreationOptions.LongRunning);
            //following commented lines do NOT change the behavior in question
            task.ContinueWith(m => Console.WriteLine("from main  "+m.Result));
            //iResult.Add(task);
          }
          Console.ReadLine();
        }
 
       //public static myMsg DoSomething()
        public static long DoSomething(int load)
        {
          Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
          //usage of either prev or following 2 lines produce the same results 
          //Stopwatch timer = new Stopwatch();  //instead of prev .StartNew();
          //timer.Start();// instead of prev .StartNew();
          Console.WriteLine("***Before calling  DoLongRunningTask()   " 
                   + timer.ElapsedMilliseconds);
          Console.WriteLine("GetHashCode  "+timer.GetHashCode());
          
          DoLongRunningTask(load); 
          timer.Stop();
          
          long elapsed = timer.ElapsedMilliseconds;
          Console.WriteLine("from DoSomething  "+ elapsed);
          
          return elapsed;//return new myMsg(timer.ElaspedMilliseconds);
        }
    
        public static void DoLongRunningTask(int load)
        {
          Thread.Sleep(2000*load);
          /*******************  another variant of calculation intensive loading
                 load = load;
                 double result = 0;
                 for (int i = 1; i < load*100000; i++)
                       result += Math.Exp(Math.Log(i) );
           */
        }
      }
    }
