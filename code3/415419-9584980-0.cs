    namespace RxTesting
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Application Thread : {0}", Thread.CurrentThread.ManagedThreadId);
                var numbers = from number in Enumerable.Range(1,10) select Process(number);
                var observableNumbers = numbers.ToObservable()
                    .ObserveOn(Scheduler.NewThread)
                    .SubscribeOn(Scheduler.NewThread);
                observableNumbers.Subscribe(
                    n => 
                        {
                            Console.WriteLine("Consuming : {0} \t on Thread : {1}", n, Thread.CurrentThread.ManagedThreadId);
                            Thread.Sleep(600);
                        }
                            );
                Console.ReadKey();
            }
            private static int Process(int number)
            {
                Thread.Sleep(500);
                Console.WriteLine("Producing : {0} \t on Thread : {1}", number,
                                  Thread.CurrentThread.ManagedThreadId);
                return number;
            }
        }
    }
