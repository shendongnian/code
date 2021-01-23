    /// <summary>
    /// Fast low CPU usage moving average based on floating point math
    /// Note: This algorithm algorithm compensates for floating point error by re-summing the buffer for every 1000 values
    /// </summary>
    public class FastMovingAverageDouble
    {
        /// <summary>
        /// Adjust this as you see fit to suit the scenario
        /// </summary>
        const int MaximumWindowSize = 100;
        /// <summary>
        /// Adjust this as you see fit
        /// </summary>
        const int RecalculateEveryXValues = 1000;
        /// <summary>
        /// Initializes moving average for specified window size
        /// </summary>
        /// <param name="_WindowSize">Size of moving average window between 2 and MaximumWindowSize 
        /// Note: this value should not be too large and also bear in mind the possibility of overflow and floating point error as this class internally keeps a sum of the values within the window</param>
        public FastMovingAverageDouble(int _WindowSize)
        {
            if (_WindowSize < 2)
            {
                _WindowSize = 2;
            }
            else if (_WindowSize > MaximumWindowSize)
            {
                _WindowSize = MaximumWindowSize;
            }
            m_WindowSize = _WindowSize;
        }
        private object SyncRoot = new object();
        private Queue<double> Buffer = new Queue<double>();
        private int m_WindowSize;
        private double m_MovingAverage = 0d;
        private double MovingSum = 0d;
        private bool BufferFull;
        private int Counter = 0;
        /// <summary>
        /// Calculated moving average
        /// </summary>
        public double MovingAverage
        {
            get
            {
                lock (SyncRoot)
                {
                    return m_MovingAverage;
                }
            }
        }
        /// <summary>
        /// Size of moving average window set by constructor during intialization
        /// </summary>
        public int WindowSize
        {
            get
            {
                return m_WindowSize;
            }
        }
        /// <summary>
        /// Add new value to sequence and recalculate moving average seee <see cref="MovingAverage"/>
        /// </summary>
        /// <param name="NewValue">New value to be added</param>
        public void AddValue(int NewValue)
        {
            lock (SyncRoot)
            {
                Buffer.Enqueue(NewValue);
                MovingSum += NewValue;
                if (!BufferFull)
                {
                    int BufferSize = Buffer.Count;
                    BufferFull = BufferSize == WindowSize;
                    m_MovingAverage = MovingSum / BufferSize;
                }
                else
                {
                    Counter += 1;
                    if (Counter > RecalculateEveryXValues)
                    {
                        MovingSum = 0;
                        foreach (double BufferValue in Buffer)
                        {
                            MovingSum += BufferValue;
                        }
                        Counter = 0;
                    }
                    MovingSum -= Buffer.Dequeue();
                    m_MovingAverage = MovingSum / WindowSize;
                }
            }
        }
    }
