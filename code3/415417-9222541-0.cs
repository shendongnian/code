    using System;
    using System.Linq;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using System.Threading;
    
    namespace RxTesting
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Console.WriteLine("Application Thread : {0}", Thread.CurrentThread.ManagedThreadId);
    
    			var numbers = from number in Enumerable.Range(1, 10) select Process(number);
    
    			var observableNumbers = numbers.ToObservable()
    //				.ObserveOn(Scheduler.NewThread)
    //				.SubscribeOn(Scheduler.NewThread)
    			;
    
    			observableNumbers.Subscribe(
    				n => {
    					Thread.Sleep(500);
    					Console.WriteLine("Consuming : {0} \t on Thread : {1}", n, Thread.CurrentThread.ManagedThreadId);
    				});
    
    			Console.WriteLine("Waiting for keyboard");
    			Console.ReadKey();
    		}
    
    		private static int Process(int number)
    		{
    			Console.WriteLine("Producing : {0} \t on Thread : {1}", number,
    							  Thread.CurrentThread.ManagedThreadId);
    
    			return number;
    		}
    	}
    }
