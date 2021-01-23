    using System;
    using System.Threading;
    
    namespace TimerDispose
    {
        /// <summary>
        /// A timer-containing class that can be disposed safely by allowing the timer 
        /// callback that it must exit/cancel its processes
        /// </summary>
        class TimerOwner : IDisposable
        {
            const int dueTime = 5 * 100;       //halve a second
            const int timerPeriod = 1 * 1000;   //Repeat timer every one second (make it Timeout.Inifinite if no repeating required)
    
            private TimerCanceller timerCanceller = new TimerCanceller();
    
            private Timer timer;
    
            public TimerOwner()
            {
                timerInit(dueTime);
            }
    
            byte[] dummy = new byte[100000];
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="dueTime">Pass dueTime for the first time, then TimerPeriod will be passed automatically</param>
            private void timerInit(int dueTime)
            {
    
                timer = new Timer(timerCallback,
                    timerCanceller,     //this is the trick, it will be kept in the heap until it is consumed by the callback 
                    dueTime,
                    Timeout.Infinite
                );
    
            }
    
            private void timerCallback(object state)
            {
                try
                {
                    //First exit if the timer was stoped before calling callback. This info is saved in state
                    var canceller = (TimerCanceller)state;
                    if (canceller.Cancelled)
                    {
                        return; //
                    }
    
                    //Your logic goes here. Please take care ! the callback might have already been called before stoping the timer
                    //and we might be already here after intending of stoping the timer. In most cases it is fine but try not to consume
                    //an object of this class because it might be already disposed. If you have to do that, hopefully it will be catched by
                    //the ObjectDisposedException below
                    
    
    
    
                    dummy[1] = 50;  //just messing up with the object after it might be disposed/nulled
    
                    //Yes, we need to check again. Read above note
                    if (canceller.Cancelled)
                    {
                        //Dispose any resource that might have been initialized above
                        return; //
                    }
    
                    if (timerPeriod != Timeout.Infinite)
                    {
                        timerInit(timerPeriod);
                    }
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine("A disposed object accessed");
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("A nulled object accessed");
                }
                catch (Exception ex)
                {
    
                }
            }
    
            public void releaseTimer()
            {
                timerCanceller.Cancelled = true;
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
            }
    
            public void Dispose()
            {
                releaseTimer();
                dummy = null;   //for testing
                GC.SuppressFinalize(this);
            }
        }
    
        class TimerCanceller
        {
            public bool Cancelled = false;
        }
    
    
        /// <summary>
        /// Testing the implementation
        /// </summary>
        class Program
        {
            static void Main(string[] args)
            {
                var list = new System.Collections.Generic.List<TimerOwner>();
                Console.WriteLine("Started initializing");
                for (int i = 0; i < 500000; i++)
                {
                    list.Add(new TimerOwner());
                }
    
                Console.WriteLine("Started releasing");
                foreach (var item in list)
                {
                    item.Dispose();
                }
    
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
