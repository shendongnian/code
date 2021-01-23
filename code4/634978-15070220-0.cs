    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        public static class Program
        {
            private static void Main(string[] args)
            {
                AutoResetEvent[] events = new AutoResetEvent[32];
                for (int i = 0; i < events.Length; ++i)
                {
                    events[i] = new AutoResetEvent(false);
                }
                // Set the first 16 auto reset events before calling CancelableWaitAll().
                for (int i = 0; i < 16; ++i)
                {
                    events[i].Set();
                }
                // Start a thread that waits five seconds and then sets the rest of the events.
                Task.Factory.StartNew(() => setEvents(events));
                Console.WriteLine("Waiting for all events to be set.");
                ManualResetEvent stopper = new ManualResetEvent(false);
                CancelableWaitAll(events, stopper);
                Console.WriteLine("Waited.");
            }
            private static void setEvents(AutoResetEvent[] events)
            {
                Thread.Sleep(5000);
                for (int i = 16; i < events.Length; ++i)
                {
                    events[i].Set();
                }
            }
            public static bool CancelableWaitAll(WaitHandle[] waitHandles, WaitHandle cancelWaitHandle)
            {
                var waitHandleList = new List<WaitHandle>();
                waitHandleList.Add(cancelWaitHandle);
                waitHandleList.AddRange(waitHandles);
                int handleIdx;
                do
                {
                    handleIdx = WaitHandle.WaitAny(waitHandleList.ToArray());
                    waitHandleList.RemoveAt(handleIdx);
                }
                while (waitHandleList.Count > 1 && handleIdx != 0);
                return handleIdx != 0;
            }
        }
    }
