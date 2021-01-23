    /// <summary>
    /// Synchronizes steps between threads.
    /// </summary>
    public class QueueSynchronizer
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="minWait">Minimum waiting time until the next try.</param>
        /// <param name="maxWait">Maximum waiting time until the next try.</param>
        public QueueSynchronizer(Int32 minWait, Int32 maxWait)
        {
        }
        private Mutex mx = new Mutex();
        /// <summary>
        /// Minimum waiting time until the next try.
        /// </summary>
        private Int32 minWait = 5;
        /// <summary>
        /// Maximum waiting time until the next try.
        /// </summary>
        private Int32 maxWait = 500;
        int currentStep = 1;
        /// <summary>
        /// Key: order in the queue; Value: Time to wait.
        /// </summary>
        private Dictionary<int, int> waitingTimeForNextMap = new Dictionary<int, int>();
        /// <summary>
        /// Synchronizes by the order in the queue. It starts from 1. If is not 
        /// its turn, the thread waits for a moment, after that, it tries again, 
        /// and so on until its turn.
        /// </summary>
        /// <param name="orderInTheQueue">Order in the queue. It starts from 1.</param>
        /// <returns>The <see cref="Mutex"/>The mutex that must be released at the end of turn.
        /// </returns>
        public Mutex Sincronize(int orderInTheQueue)
        {
            do
            {
                //while it is not the turn, the thread will stay in this loop and sleeping for 100, 200, ... 1000 ms
                if (orderInTheQueue != this.currentStep)
                {
                    //The next in queue will be waiting here (other threads).
                    mx.WaitOne();
                    mx.ReleaseMutex();
                    //Prevents 100% processing while the current step does not happen
                    if (!waitingTimeForNextMap.ContainsKey(orderInTheQueue))
                    {
                        waitingTimeForNextMap[orderInTheQueue] = this.minWait;
                    }
                    Thread.Sleep(waitingTimeForNextMap[orderInTheQueue]);
                    waitingTimeForNextMap[orderInTheQueue] = Math.Min(waitingTimeForNextMap[orderInTheQueue] * 2, this.maxWait);
                }
            } while (orderInTheQueue != this.currentStep);
            mx.WaitOne();
            currentStep++;
            return mx;
        }
    }
    
