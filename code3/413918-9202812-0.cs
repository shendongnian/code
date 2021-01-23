    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace TestThreadLocal
    {
      internal class Program
      {
        public class EvaluationContext
        {
          public int A { get; set; }
          public int B { get; set; }
        }
    
        public static class FormulasRunTime
        {
          public static ThreadLocal<EvaluationContext> Context = new ThreadLocal<EvaluationContext>();
    
          public static int SomeFunction()
          {
            EvaluationContext ctx = Context.Value;
            return ctx.A + ctx.B;
          }
    
          public static int SomeFunction(EvaluationContext context)
          {
            return context.A + context.B;
          }
        }
    
    
    
        private static void Main(string[] args)
        {
    
          Stopwatch stopwatch = Stopwatch.StartNew();
          int N = 10000;
          Task<int>[] tasks = new Task<int>[N];
          int sum = 0;
          for (int i = 0; i < N; i++)
          {
            int x = i;
            tasks[i] = Task.Factory.StartNew(() =>
                                                     {
                                                       //Console.WriteLine("Starting {0}, thread {1}", x, Thread.CurrentThread.ManagedThreadId);
                                                       FormulasRunTime.Context.Value = new EvaluationContext {A = 0, B = x};
                                                       return FormulasRunTime.SomeFunction();
                                                     });
            sum += i;
          }
          Task.WaitAll(tasks);
          
          Console.WriteLine("Using ThreadLocal: It took {0} millisecs and the sum is {1}", stopwatch.ElapsedMilliseconds, tasks.Sum(t => t.Result));
          Console.WriteLine(sum);
          stopwatch = Stopwatch.StartNew();
          
          for (int i = 0; i < N; i++)
          {
            int x = i;
            tasks[i] = Task.Factory.StartNew(() =>
            {
              return FormulasRunTime.SomeFunction(new EvaluationContext { A = 0, B = x });
            });
          
          }
          Task.WaitAll(tasks);
    
          Console.WriteLine("Using parameter: It took {0} millisecs and the sum is {1}", stopwatch.ElapsedMilliseconds, tasks.Sum(t => t.Result));
          Console.ReadKey();
        }
      }
    }
