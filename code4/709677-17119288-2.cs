    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ThrottledAsync
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Queue up simultaneous calls.
                var call1 = MakeThrottledCall();
                var call2 = MakeThrottledCall();
                var call3 = MakeThrottledCall();
                Task.WaitAll(call1, call2, call3);
                Console.ReadLine();
            }
            // Used to throttle our web service calls.
            // Max degree of parallelism: 1.
            private static SemaphoreSlim Semaphore = new SemaphoreSlim(1);
            private static async Task MakeThrottledCall()
            {
                // Wait for the previous call
                // (and delay task) to complete.
                await Semaphore.WaitAsync();
                try
                {
                    await MakeCallToWebService();
                
                    // Report the completion of your web service call here.
                
                    // Delay for a bit before releasing the semaphore.
                    await Task.Delay(1000);
                }
                finally
                {
                    Semaphore.Release();
                }
            }
            private static async Task MakeCallToWebService()
            {
                // Simulate network delay.
                await Task.Delay(new Random().Next(5, 10));
            
                Console.WriteLine("WebServiceCall: {0:HH:mm:ss.ffff}", DateTime.Now);
            }
        }
    }
