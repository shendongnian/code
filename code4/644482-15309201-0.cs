    using System;
    using System.Threading;
    
    namespace bothCallWaitOne
    {
      class Program
      {
        static AutoResetEvent autoEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
          Test();
          Console.ReadLine();
        }
        private static void Test()
        {
          // two threads - waiting for the same autoreset event
          // start it unset i.e. closed i.e. anything calling WaitOne() will block
          //AutoResetEvent autoEvent = new AutoResetEvent(false);
    
          //WriteSomeMessageToTheConsole();
          Thread thread1 = new Thread(new ThreadStart(WriteSomeMessageToTheConsole));
          thread1.Name = "1111111111";
          thread1.Start();  // this will now block until we set the event
    
          //Thread thread2 = new Thread(new ThreadStart(WriteSomeOtherMessageToTheConsole));
          Thread thread2 = new Thread(new ThreadStart(WriteSomeOtherMessageToTheConsole));
          thread2.Name = "222222222222";
          thread2.Start();  // this will now also block until we set the event
    
          // simulate some other stuff
          Console.WriteLine("Doing stuff...");
          Thread.Sleep(5000);
          Console.WriteLine("Stuff done.");
    
          // set the event - I thought this would mean both waiting threads are allowed to continue
          // BUT thread2 runs and thread1 stays blocked indefinitely
          // So I guess I was wrong and that Set only releases one thread in WaitOne()?
          // And why thread2 first?
          autoEvent.Set();
        }
        static void WriteSomeMessageToTheConsole()
        {
          autoEvent.WaitOne();//Cannot relve symbol autoEvent
          while(true)
            Console.WriteLine(Thread.CurrentThread.Name+"****");
        }
        static void WriteSomeOtherMessageToTheConsole()
        {
          autoEvent.WaitOne();//Cannot relve symbol autoEvent
          while(true)
          Console.WriteLine(Thread.CurrentThread.Name);
        }
      }
    }
