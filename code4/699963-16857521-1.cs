       class Program
       {
          static volatile int num = 0;
    
          // Initialized set to ensure that the producer goes first.
          static EventWaitHandle consumed = new AutoResetEvent(true);
    
          // Initialized not set to ensure consumer waits until first producer run.
          static EventWaitHandle produced = new AutoResetEvent(false);
    
          static void Main(string[] args)
          {
             new Thread(Consumer).Start();
             new Thread(Producer).Start();
          }
    
          static void Producer()
          {
             while (true)
             {
                consumed.WaitOne();
                num++;
                Console.WriteLine("Produced " + num);
                Thread.Sleep(1000);
                produced.Set();               
             }
          }
    
          static void Consumer()
          {
             while (true)
             {
                produced.WaitOne();
                Console.WriteLine("Consumed " + num);
                Thread.Sleep(1000);
                num--;
                consumed.Set();               
             }
          }
       }
