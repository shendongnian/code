    using System;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            static YourSnifferClass sniffer = new YourSnifferClass();
            static AutoResetEvent done_event = new AutoResetEvent(false);
            static void Main(string[] args)
            {           
                sniffer.Start();
                // Wait for 15 seconds or until the handle is set (if you had a
                // Stopped event on your sniffer, you could set this wait handle
                // there: done_event.Set()
                done_event.WaitOne(TimeSpan.FromSeconds(15));
                // stop the sniffer
                sniffer.Stop();
            }
        }
    }
