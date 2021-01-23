    using System;
    using System.Collections.Concurrent;;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
	namespace DemoRX
	{
	    class Program
	    {
	        static void Main(string[] args)
	        {
	            BlockingCollection<string> myQueue = new BlockingCollection<string>();
	            {                
	                IObservable<string> ob = myQueue.
                      GetConsumingEnumerable().
                      ToObservable(TaskPoolScheduler.Default);
	                                
	                ob.Subscribe(p =>
	                {
	                    // This will get called in the future whenever anything 
                        // appears on myQueue.
	                    Console.Write("Consuming: {0}\n",p);                    
	                });
	            }
	            // Now, adding items to myQueue will trigger the item to be consumed
                // in the handler.
	            myQueue.Add("a");
	            myQueue.Add("b");
	            myQueue.Add("c");           
	            Console.Write("[any key to exit]\n");
	            Console.ReadKey();
	        }
	    }
	}
