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
                MakeThrottledCall();
                MakeThrottledCall();
                MakeThrottledCall();
                MakeThrottledCall();
                Console.ReadLine();
            }
            // Used to throttle our web service calls.
            // Max degree of parallelism: 1.
            private static readonly SemaphoreSlim WebServiceMutex = new SemaphoreSlim(1, 1);
            private static async void MakeThrottledCall()
            {
                // Wait for the previous call
                // (and delay task) to complete.
                await WebServiceMutex.WaitAsync();
                try
                {
                    await MakeCallToWebService();
                
                    // Report the completion of your web service call if necessary.
                
                    // Delay for a bit before releasing the semaphore.
                    await Task.Delay(1000);
                }
                finally
                {
                    // Allow the next web service call to go through.
                    WebServiceMutex.Release();
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
